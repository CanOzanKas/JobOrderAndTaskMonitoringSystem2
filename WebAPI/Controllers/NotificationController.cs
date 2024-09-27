using AppServices.DTOs.DepartmentDTOs;
using AppServices.Service.DepartmentServices;
using AppServices.Service.NotificationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController:ControllerBase {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService) {
            _notificationService = notificationService;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult GetAllNotificationsByUserId(int id) {
            return Ok(_notificationService.GetAllNotificationsByUserId(id));
        }
        


    }
}
