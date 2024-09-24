using AppCore.Entities;
using AppCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.JobOrderDTOs {
    public class CreateJobOrderDTO {
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityEnum Priority { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public JobOrderStatusEnum Status { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
