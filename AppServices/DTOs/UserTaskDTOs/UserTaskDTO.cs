﻿using AppCore.Entities;
using AppCore.Enums;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.UserTaskDTOs {
    public class UserTaskDTO {
        public int Id { get; set; }

        public int JobOrderId { get; set; }
        public JobOrderDTO JobOrder { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int AssignedTo { get; set; }
        public UserDTO AssignedUser { get; set; }

        public DateTime DueDate { get; set; }
        public UserTaskStatusEnum Status { get; set; }
    }
}
