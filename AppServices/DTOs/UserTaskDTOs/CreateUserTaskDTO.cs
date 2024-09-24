using AppCore.Entities;
using AppCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.UserTaskDTOs {
    public class CreateUserTaskDTO {
        public int JobOrderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
    }
}
