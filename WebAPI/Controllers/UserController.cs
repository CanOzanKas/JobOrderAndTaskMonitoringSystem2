using AppServices.DTOs.DepartmentDTOs;
using AppServices.DTOs.UserDTOs;
using AppServices.Service.UserServices;
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
        public IActionResult GetAllDepartments() {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id) {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateUserDTO createUserDTO) {
            _userService.CreateUser(createUserDTO);
            return Ok("User added successfully!");
        }

        [HttpPut]
        public IActionResult UpdateDepartment(UserDTO userDTO) {
            _userService.UpdateUser(userDTO);
            return Ok("User updated successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int id) {
            _userService.DeleteUser(id);
            return Ok("User deleted successfully!");
        }


    }
}
