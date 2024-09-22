using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppServices.Service.DepartmentServices;
namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController:ControllerBase {
        private readonly IDepartmentService departmentService;

        

    }
}
