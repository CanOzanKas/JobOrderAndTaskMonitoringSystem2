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

        public void CreateTask(CreateUserTaskDTO userTaskDTO);
        public void UpdateTask(UserTaskDTO userTaskDTO);
        public void DeleteTask(int id);
        public UserTaskDTO GetUserTaskById(int id);
        public List<UserTaskDTO> GetAllUserTasks();
        public List<UserTaskDTO> GetAllUserTasksByStatus(UserTaskStatusEnum status);
        public List<UserTaskDTO> GetAllUserTasksByDepartment(DepartmentDTO departmentDTO);
        public JobOrderDTO GetRelatedJob(int id);
    
    }
}
