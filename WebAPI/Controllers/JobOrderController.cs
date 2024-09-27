using AppCore.Enums;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.Service.JobOrderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class JobOrderController:ControllerBase {
        private readonly IJobOrderService _jobOrderService;

        public JobOrderController(IJobOrderService jobOrderService) { 
            _jobOrderService = jobOrderService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetAllJobOrders() { 
            return Ok(_jobOrderService.GetAllJobOrders());
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetJobOrderById(int id) { 
            return Ok(_jobOrderService.GetJobOrderById(id));
        }
        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetJobOrdersByStatus(JobOrderStatusEnum status) {
            return Ok(_jobOrderService.GetJobOrdersByStatus(status));
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateJobOrder(CreateJobOrderDTO createJobOrderDTO) {
            _jobOrderService.CreateJob(createJobOrderDTO);
            return Ok("Job Order created successfully!");
        }
        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult UpdateJobOrder(JobOrderDTO jobOrderDTO) { 
            _jobOrderService.UpdateJobOrder(jobOrderDTO);
            return Ok("Job Order updated successfully!");
        }
        [HttpDelete]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult DeleteJobOrder(int id) { 
            _jobOrderService.DeleteJobOrder(id);
            return Ok("Job Order deleted successfully!");
        }

        [HttpGet("JobOrderReport")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetJobOrderReport() {
            return Ok(_jobOrderService.GetJobOrderReport());
        }

    }
}
