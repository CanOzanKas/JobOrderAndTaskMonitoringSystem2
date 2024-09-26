using AppCore.Enums;
using AppServices.DTOs.JobOrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.JobOrderServices {
    public interface IJobOrderService {

        public void CreateJob(CreateJobOrderDTO createJobOrderDTO);

        public JobOrderDTO GetJobOrderById(int id);
        public List<JobOrderDTO> GetAllJobOrders();
        public void DeleteJobOrder(int id);
        public void UpdateJobOrder(JobOrderDTO jobOrderDTO);
        public List<JobOrderDTO> GetJobOrdersByStatus(JobOrderStatusEnum status);
        public JobOrderReportDTO GetJobOrderReport();
    }
}
