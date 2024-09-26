using AppCore.Entities;
using AppCore.Enums;
using AppServices.DTOs.DepartmentDTOs;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.DTOs.UserTaskDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.UserTaskServices {
    public interface IUserTaskService {

        public void CreateUserTask(CreateUserTaskDTO userTaskDTO);
        public void UpdateUserTask(UpdateUserTaskDTO userTaskDTO);
        public void DeleteUserTask(int id);
        public UserTaskDTO GetUserTaskById(int id);
        public List<UserTaskDTO> GetAllUserTasks();
        public List<UserTaskDTO> GetAllUserTasksByStatus(UserTaskStatusEnum status);
        public UserTasksByDepartmentDTO GetAllUserTasksByDepartment(int departmentId);
        public List<UserTaskDTO> GetAllUserTasksByUser(int userId);
        public UserTaskRelatedJobOrderDTO GetRelatedJob(int id);
        public UserTaskReportDTO GetUserTaskReport();
    }
}
