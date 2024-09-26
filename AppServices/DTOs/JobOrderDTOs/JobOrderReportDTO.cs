using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.JobOrderDTOs {
    public class JobOrderReportDTO {
        public int TotalOpenOrders { get; set; }
        public int TotalClosedOrders { get; set; }
        public int TotalCancelledOrders { get; set; }
        public List<JobOrderDetailsDTO> JobOrderDetails { get; set; }
    }
}
