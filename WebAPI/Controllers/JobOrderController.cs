using AppCore.Enums;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.Service.JobOrderServices;
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
        public IActionResult GetAllJobOrders() { 
            return Ok(_jobOrderService.GetAllJobOrders());
        }
        [HttpGet("{id}")]
        public IActionResult GetJobOrderById(int id) { 
            return Ok(_jobOrderService.GetJobOrderById(id));
        }
        [HttpGet("{status}")]
        public IActionResult GetJobOrdersByStatus(JobOrderStatusEnum status) {
            return Ok(_jobOrderService.GetJobOrdersByStatus(status));
        }
        [HttpPost]
        public IActionResult CreateJobOrder(CreateJobOrderDTO createJobOrderDTO) {
            _jobOrderService.CreateJob(createJobOrderDTO);
            return Ok("Job Order created successfully!");
        }
        [HttpPut]
        public IActionResult UpdateJobOrder(JobOrderDTO jobOrderDTO) { 
            _jobOrderService.UpdateJobOrder(jobOrderDTO);
            return Ok("Job Order updated successfully!");
        }
        [HttpDelete]
        public IActionResult DeleteJobOrder(int id) { 
            _jobOrderService.DeleteJobOrder(id);
            return Ok("Job Order deleted successfully!");
        }


    }
}
