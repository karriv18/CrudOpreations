using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOpreations.Model.Request;
using CrudOpreations.Routing;
using CrudOpreations.Model.Response;
using CrudOpreations.Services;
namespace CrudOpreations.Controllers
{
    public class UserMangementController : ControllerBase
    {
        private readonly IUserManagementServices userManagementServices;

        public UserMangementController(IUserManagementServices _userManagementServices)
        {
            userManagementServices = _userManagementServices;
        }
        [HttpPost(ApiRoute.Create)]
        public async Task<IActionResult> CreateUserAsync(UserRequest request, CancellationToken cancellationToken)
        {
            bool result = await userManagementServices.CreateAsync(request, cancellationToken);

            if (!result) 
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Internal Server Error" });

            return Ok(result);
        }

        [HttpGet(ApiRoute.Get)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await userManagementServices.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpGet(ApiRoute.GetAll)]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var users = await userManagementServices.GetAllAsync();
            return Ok(users);
        }

        [HttpPost(ApiRoute.Update)]
        public async Task<IActionResult> UpdateUserAsync(int id, UserRequest request)
        {
            var result = await userManagementServices.UpdateAsync(id, request);
            return Ok(result);
        }        
        
        [HttpPost(ApiRoute.Delete)]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await userManagementServices.DeleteAsync(id);  
            return Ok();
        }



    }
}
