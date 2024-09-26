using AppCore.Enums;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.UserTaskDTOs {
    public class UserTaskInfoDTO {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserCredentialsDTO AssignedUserCredentials { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

    }
}
