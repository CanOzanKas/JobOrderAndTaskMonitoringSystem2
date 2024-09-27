using AppServices.DTOs.DepartmentDTOs;
using AppServices.Service.DepartmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController:ControllerBase {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) { 
            _departmentService = departmentService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetAllDepartments() {
            return Ok(_departmentService.GetAllDepartments());
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetDepartmentById(int id) {
            return Ok(_departmentService.GetDepartmentById(id));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateDepartment(CreateDepartmentDTO createDepartmentDTO) {
            _departmentService.CreateDepartment(createDepartmentDTO);
            return Ok("Department added successfully!");
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateDepartment(DepartmentDTO departmentDTO) {
            _departmentService.UpdateDepartment(departmentDTO);
            return Ok("Department updated successfully!");
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDepartment(int id) {
            _departmentService.DeleteDepartment(id);
            return Ok("Department deleted successfully!");
        }
    }
}
