using AppCore.Entities;
using AppCore.Enums;
using AppPersistence.Repositories.GenericRepo;
using AppServices.DTOs.DepartmentDTOs;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.DTOs.UserTaskDTOs;
using AppServices.Service.JobOrderServices;
using AppServices.Service.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.UserTaskServices {
    public class UserTaskService:IUserTaskService {

        private readonly IGenericRepository<UserTask> _repository;
        private readonly IJobOrderService _jobOrderService;
        private readonly IUserService _userService;

        public UserTaskService(IGenericRepository<UserTask> repository, IJobOrderService jobOrderService, IUserService userService) { 
            _repository = repository; 
            _jobOrderService = jobOrderService;
            _userService = userService;
        }

        public void CreateTask(CreateUserTaskDTO userTaskDTO) {
            var jobOrderDTO = _jobOrderService.GetJobOrderById(userTaskDTO.JobOrderId);
            var jobOrder = new JobOrder {
                Id = jobOrderDTO.Id,
                Title = jobOrderDTO.Title,
                Description = jobOrderDTO.Description,
                Priority = jobOrderDTO.Priority,
                EstimatedCompletionDate = jobOrderDTO.EstimatedCompletionDate,
                Status = jobOrderDTO.Status,
                CreatedDate = jobOrderDTO.CreatedDate,
                UpdatedDate = jobOrderDTO.UpdatedDate,
                Tasks = jobOrderDTO.Tasks,
            };

            var userDTO = _userService.GetUserById(userTaskDTO.AssignedTo);
            var user = new User {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                Email = userDTO.Email,
                Role = userDTO.Role,
                CreatedDate = userDTO.CreatedDate,
                UpdatedDate = userDTO.UpdatedDate,
                Department = userDTO.Department
            };

            _repository.Create(new UserTask {
                JobOrderId = userTaskDTO.JobOrderId,
                JobOrder = jobOrder,
                Title = userTaskDTO.Title,
                Description = userTaskDTO.Description,
                AssignedTo = userTaskDTO.AssignedTo,
                AssignedUser = user,
                DueDate = userTaskDTO.DueDate,
                Status = UserTaskStatusEnum.InProgress,
            });

        }

        public void DeleteTask(int id) {
            throw new NotImplementedException();
        }

        public List<UserTaskDTO> GetAllUserTasks() {
            throw new NotImplementedException();
        }

        public List<UserTaskDTO> GetAllUserTasksByDepartment(DepartmentDTO departmentDTO) {
            throw new NotImplementedException();
        }

        public List<UserTaskDTO> GetAllUserTasksByStatus(UserTaskStatusEnum status) {
            throw new NotImplementedException();
        }

        public JobOrderDTO GetRelatedJob(int id) {
            throw new NotImplementedException();
        }

        public UserTaskDTO GetUserTaskById(int id) {
            throw new NotImplementedException();
        }

        public void UpdateTask(UserTaskDTO userTaskDTO) {
            throw new NotImplementedException();
        }
    }
}
