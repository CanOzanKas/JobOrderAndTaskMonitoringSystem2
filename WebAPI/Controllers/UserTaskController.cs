using AppCore.Enums;
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

        [HttpGet("ById/{id}")]
        public IActionResult GetUserTaskById(int id) {
            return Ok(_userTaskService.GetUserTaskById(id));
        }

        [HttpGet("AllByStatus/{status}")]
        public IActionResult GetUserTasksByStatus(UserTaskStatusEnum status) {
            return Ok(_userTaskService.GetAllUserTasksByStatus(status));
        }

        [HttpGet("AllByDepartment/{departmentId}")]
        public IActionResult GetUserTasksByDepartment(int departmentId) {
            return Ok(_userTaskService.GetAllUserTasksByDepartment(departmentId));
        }

        [HttpGet("RelatedJob/{id}")]
        public IActionResult GetRelatedJobOfUserTask(int id) {
            return Ok(_userTaskService.GetRelatedJob(id));
        }

        [HttpGet("AllByUser/{userId}")]
        public IActionResult GetUserTasksByUser(int userId) {
            return Ok(_userTaskService.GetAllUserTasksByUser(userId));
        }


        [HttpPost]
        public IActionResult CreateUserTask(CreateUserTaskDTO createUserTaskDTO) {
            _userTaskService.CreateUserTask(createUserTaskDTO);
            return Ok("Task created successfully!");
        }

        [HttpPut]
        public IActionResult UpdateUserTask(UpdateUserTaskDTO updateUserTaskDTO) {
            _userTaskService.UpdateUserTask(updateUserTaskDTO);
            return Ok("Task updated successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteUserTask(int id) { 
            _userTaskService.DeleteUserTask(id);
            return Ok("Task deleted successfully!");
        }
        [HttpGet("UserTaskReport")]
        public IActionResult GetUserTaskReport() {
            return Ok(_userTaskService.GetUserTaskReport());
        }
    }
}
