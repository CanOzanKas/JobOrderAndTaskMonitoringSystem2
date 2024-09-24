using AppServices.DTOs.UserDTOs;
using AppServices.DTOs.UserTaskDTOs;
using AppServices.Service.UserTaskServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController:ControllerBase {
        private readonly IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService) { 
            _userTaskService = userTaskService;
        }

        [HttpGet]
        public IActionResult GetAllUserTasks() { 
            return Ok(_userTaskService.GetAllUserTasks());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserTaskById(int id) {
            return Ok(_userTaskService.GetUserTaskById(id));
        }

        [HttpPost]
        public IActionResult CreateUserTask(CreateUserTaskDTO createUserTaskDTO) {
            _userTaskService.CreateTask(createUserTaskDTO);
            return Ok("Task created successfully!");
        }

        [HttpPut]
        public IActionResult UpdateUserTask(UserTaskDTO userTaskDTO) {
            _userTaskService.UpdateTask(userTaskDTO);
            return Ok("Task updated successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteUserTask(int id) { 
            _userTaskService.DeleteTask(id);
            return Ok("Task deleted successfully!");
        }
    }
}
