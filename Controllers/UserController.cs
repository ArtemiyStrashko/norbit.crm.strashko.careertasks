using Microsoft.AspNetCore.Mvc;
using norbit.crm.strashko.careertasks.backend.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace norbit.crm.strashko.careertasks.backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("/getUsers")]
        public IResult Get()
        {
            var userCollection = UserDBService.GetUsers();
            return Results.Ok(userCollection);
        }

        [HttpGet("/getUserById/{id}")]
        public IResult GetUserById(Guid id)
        {
            var userToReturn = UserDBService.GetUserById(id);
            
            return (userToReturn != null)
                ? Results.Ok(userToReturn)
                : Results.NotFound($"User with Id: {id} not found");
        }

        [HttpPost("/addUser")]
        public IResult AddUser(User user)
        {
            var createdUserId = UserDBService.CreateUser(user);

            return createdUserId.HasValue
                ? Results.Ok(createdUserId.Value)
                : Results.BadRequest();
        }

        [HttpPut("/updateUser")]
        public IResult UpdateUser(User user) 
        {
            var updatedUser = UserDBService.UpdateUser(user);

            return updatedUser.HasValue
                ? Results.Ok(updatedUser.Value)
                : Results.BadRequest();
        }

        [HttpDelete("/deleteUserById/{id}")]
        public IResult DeleteUser(Guid id)
        {
            bool deleteUserSuccessful = UserDBService.DeleteUserById(id);

            return deleteUserSuccessful
                ? Results.Ok(id)
                : Results.BadRequest();
        }

        [HttpPost("/file/uploadUserFile")]
        public IResult UploadFile(IFormFile file)
        {
            try
            {
                UserDBService.UploadUserCollectionFromFile(file);

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
