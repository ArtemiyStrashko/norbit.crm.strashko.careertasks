using System.Text.Json;
using System.Text;

namespace norbit.crm.strashko.careertasks.backend.Models
{
    public class FileUploadService
    {
        public static void ProcessFile(IFormFile file)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var sb = new StringBuilder();
                    var runTasks = new List<Task>();
                    var token = new CancellationToken();

                    using (var fileReader = new StreamReader(file.OpenReadStream()))
                    {
                        sb.Append(fileReader.ReadToEnd());
                    }

                    var userCollection = JsonSerializer.Deserialize<List<User>>(sb.ToString());

                    if (userCollection == null)
                    {
                        throw new ArgumentException("Некорректный JSON-файл");
                    }

                    var sortedUserCollection = userCollection
                        .OrderByDescending(user => user.ModifiedOn)
                        .GroupBy(user => user.Id)
                        .Select(user => user.First())
                        .ToList();

                    for (int userCounter = 0; userCounter < sortedUserCollection.Count; userCounter += 100)
                    {
                        while (runTasks.Count >= 5)
                        {
                            Task.Delay(1000, token).Wait(token);
                            runTasks.RemoveAll(task => task.IsCompleted || task.IsCanceled || task.IsFaulted);
                        }

                        runTasks.Add(Task.Run(() =>
                        {
                            UserDBService.ProcessUserCollection(sortedUserCollection
                                .Skip(userCounter)
                                .Take(100));
                        }));

                        while (runTasks.Any(task => task.Status == TaskStatus.Running))
                        {

                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
