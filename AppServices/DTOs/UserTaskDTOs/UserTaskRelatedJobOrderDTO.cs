using AppCore.Entities;
using AppCore.Enums;
using AppServices.DTOs.JobOrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.UserTaskDTOs {
    public class UserTaskRelatedJobOrderDTO {
        public JobOrderDTO JobOrderDTO { get; set; }
    }
}
