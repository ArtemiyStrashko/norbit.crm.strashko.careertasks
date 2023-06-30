using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Text.Json;
using System.Text;
using System.Reflection.Metadata.Ecma335;

namespace norbit.crm.strashko.careertasks.backend.Models
{
    public static class UserDBService
    {
        public static List<User> GetUsers()
        {
            using (var db = new DBContext())
            {
                var userCollection = db.Users.ToList();
                return userCollection;
            }
        }

        public static User? GetUserById(Guid userId) 
        {
            using (var db = new DBContext())
            {
                var findedUser = db.Users.FirstOrDefault(x => x.Id == userId);
                return findedUser;
            }
        }

        public static Guid? CreateUser(User userToCreate)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var createdUser = db.Users.Add(userToCreate);
                    var createdUserId = createdUser.Entity.Id;

                    var createdRowCount = db.SaveChanges();
                    return (createdRowCount > 0)
                        ? createdUserId 
                        : null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Guid? UpdateUser(User userToUpdate) 
        {
            try
            {
                using (var db = new DBContext())
                {
                    var updatedUser = db.Users.Update(userToUpdate);
                    var updatedUserId = updatedUser.Entity.Id;

                    var updatedRowCount = db.SaveChanges();
                    return (updatedRowCount > 0)
                        ? updatedUserId 
                        : null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool DeleteUserById(Guid userId)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var userToDelete = GetUserById(userId);

                    if (userToDelete == null)
                    {
                        return false;
                    }

                    db.Users.Remove(userToDelete);
                    var deletedRowCount = db.SaveChanges();

                    return deletedRowCount > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UploadUserCollectionFromFile(IFormFile file)
        {
            try
            {
                FileUploadService.ProcessFile(file);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ProcessUserCollection(IEnumerable<User> userToProcessCollection)
        {
            try
            {
                foreach (var userToProcess in userToProcessCollection)
                {
                    if (GetUserById(userToProcess.Id) != null)
                    {
                        UpdateUser(userToProcess);
                    }
                    else
                    {
                        CreateUser(userToProcess);
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
