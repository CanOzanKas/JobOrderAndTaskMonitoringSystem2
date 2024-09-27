using AppServices.DTOs.UserDTOs;
using AppServices.Service.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase {
        private readonly IUserService _userService;

        public UserController(IUserService userService) { 
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetAllUsers() {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetUserById(int id) {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateUser(CreateUserDTO createUserDTO) {
            _userService.CreateUser(createUserDTO);
            return Ok("User added successfully!");
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult UpdateUser(UserDTO userDTO) {
            _userService.UpdateUser(userDTO);
            return Ok("User updated successfully!");
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult DeleteUser(int id) {
            _userService.DeleteUser(id);
            return Ok("User deleted successfully!");
        }
        [HttpGet("ByDepartment/{departmentId}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetUsers(int departmentId) {
            return Ok(_userService.GetAllUsersByDepartment(departmentId));
        
        }


    }
}
