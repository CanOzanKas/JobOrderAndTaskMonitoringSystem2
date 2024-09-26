using AppServices.DTOs.DepartmentDTOs;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.UserTaskDTOs {
    public class UserTasksByDepartmentDTO {
        public string DepartmentName { get; set; }
        public List<UserTaskInfoDTO> UserTaskInfo{ get; set; }
    }
}
