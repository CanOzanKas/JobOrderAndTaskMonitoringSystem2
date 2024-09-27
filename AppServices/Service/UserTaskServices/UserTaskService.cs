using AppCore.Entities;
using AppCore.Enums;
using AppPersistence.Repositories.GenericRepo;
using AppServices.DTOs.DepartmentDTOs;
using AppServices.DTOs.JobOrderDTOs;
using AppServices.DTOs.NotificationDTOs;
using AppServices.DTOs.UserDTOs;
using AppServices.DTOs.UserTaskDTOs;
using AppServices.Service.DepartmentServices;
using AppServices.Service.JobOrderServices;
using AppServices.Service.NotificationServices;
using AppServices.Service.UserServices;
using Microsoft.VisualBasic;
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
        private readonly IDepartmentService _departmentService;
        private readonly INotificationService _notificationService;
        public UserTaskService(IGenericRepository<UserTask> repository, IJobOrderService jobOrderService, IUserService userService, IDepartmentService departmentService, INotificationService notificationService) { 
            _repository = repository; 
            _jobOrderService = jobOrderService;
            _userService = userService;
            _departmentService = departmentService;
            _notificationService = notificationService;
        }

        public void CreateUserTask(CreateUserTaskDTO userTaskDTO) {
            var userTask = _repository.CreateAndReturn(new UserTask {
                JobOrderId = userTaskDTO.JobOrderId,
                Title = userTaskDTO.Title,
                Description = userTaskDTO.Description,
                AssignedTo = userTaskDTO.AssignedTo,
                DueDate = userTaskDTO.DueDate,
                Status = UserTaskStatusEnum.InProgress,
            });
            
            _notificationService.CreateNotification(new CreateNotificationDTO {
                Message = "New User Task is created",
                UserId = userTaskDTO.AssignedTo,
                UserTaskId = userTask.Id,
                CreatedDate = DateTime.Now,
            });
            

        }

        public void DeleteUserTask(int id) {
            var userTask = _repository.GetById(id);
            _notificationService.CreateNotification(new CreateNotificationDTO {
                Message = "User Task with Id " + id +" is deleted!",
                UserId = userTask.AssignedTo,
                UserTaskId = id,
                CreatedDate = DateTime.Now,
            });
            _repository.Delete(userTask);
            

        }

        public List<UserTaskDTO> GetAllUserTasks() {
            return _repository.GetAll().Select(ut => new UserTaskDTO {
                Id = ut.Id,
                JobOrderId = ut.JobOrderId,
                JobOrder = _jobOrderService.GetJobOrderById(ut.JobOrderId),
                Title = ut.Title,
                Description = ut.Description,
                AssignedTo = ut.AssignedTo,
                AssignedUser = _userService.GetUserById(ut.AssignedTo),
                DueDate = ut.DueDate,
                Status = UserTaskStatusEnum.InProgress,
            }).ToList();
        }

        public UserTasksByDepartmentDTO GetAllUserTasksByDepartment(int departmentId) {
            var userTasks = _repository.GetAll();
            var departmentName = _departmentService.GetDepartmentById(departmentId).DepartmentName;
            var userTasksByDepartment = userTasks.Where(ut => _userService.GetUserById(ut.AssignedTo).DepartmentId == departmentId).ToList();
            var userTasksByDepartmentDTO = new UserTasksByDepartmentDTO {
                DepartmentName = departmentName,
                UserTaskInfo = new List<UserTaskInfoDTO>()
            };
            foreach(UserTask userTaskByDepartment in userTasksByDepartment) {
                var userDTO = _userService.GetUserById(userTaskByDepartment.AssignedTo);
                string Role = userDTO.Role == RoleEnum.Manager ? "Manager"  : "Employee";
                string Status = userTaskByDepartment.Status == UserTaskStatusEnum.InProgress ? "In Progress" : userTaskByDepartment.Status == UserTaskStatusEnum.Pending ? "Pending" : "Completed";
                var userTaskInfoDTO = new UserTaskInfoDTO {
                    Title = userTaskByDepartment.Title,
                    Description = userTaskByDepartment.Description,
                    AssignedUserCredentials = new UserCredentialsDTO {
                        Id = userDTO.Id,
                        Name = userDTO.Name,
                        Surname = userDTO.Surname,
                        Email = userDTO.Email,
                        Role = Role
                    },
                    DueDate = userTaskByDepartment.DueDate,
                    Status = Status
                };
                userTasksByDepartmentDTO.UserTaskInfo.Add(userTaskInfoDTO);
            }
            return userTasksByDepartmentDTO; 
        }

        public List<UserTaskDTO> GetAllUserTasksByStatus(UserTaskStatusEnum status) {
            var userTasks = _repository.GetAll();
            return userTasks
                .Where(ut => ut.Status == status)
                .Select(ut => new UserTaskDTO {
                    Id = ut.Id,
                    JobOrderId = ut.JobOrderId,
                    Title = ut.Title,
                    Description = ut.Description,
                    AssignedTo = ut.AssignedTo,
                    DueDate = ut.DueDate,
                    Status = ut.Status
                }).ToList();
        }

        public List<UserTaskDTO> GetAllUserTasksByUser(int id) {
            var userTasks = _repository.GetAll();
            return userTasks
                .Where(ut => ut.AssignedTo == id)
                .Select(ut => new UserTaskDTO {
                    Id = ut.Id,
                    JobOrderId = ut.JobOrderId,
                    Title = ut.Title,
                    Description = ut.Description,
                    AssignedTo= ut.AssignedTo,
                    DueDate = ut.DueDate,
                    Status= ut.Status
                }).ToList();
        }

        public UserTaskRelatedJobOrderDTO GetRelatedJob(int id) {
            var jobOrder = _jobOrderService.GetJobOrderById(_repository.GetById(id).JobOrderId);
            var jobOrderDTO = new JobOrderDTO {
                Id = jobOrder.Id,
                Title = jobOrder.Title,
                Description = jobOrder.Description,
                Priority = jobOrder.Priority,
                EstimatedCompletionDate = jobOrder.EstimatedCompletionDate,
                Status = jobOrder.Status,
                CreatedDate = jobOrder.CreatedDate,
                UpdatedDate = jobOrder.UpdatedDate
            };
            return new UserTaskRelatedJobOrderDTO { 
                JobOrderDTO = jobOrderDTO,
            };
        }

        public UserTaskDTO GetUserTaskById(int id) {
            var userTask = _repository.GetById(id);
            var jobOrderDTO = _jobOrderService.GetJobOrderById(userTask.JobOrderId);
            var userDTO = _userService.GetUserById(userTask.AssignedTo);

            return new UserTaskDTO {
                Id = userTask.Id,
                JobOrderId = userTask.JobOrderId,
                JobOrder = jobOrderDTO,
                Title = userTask.Title,
                Description = userTask.Description,
                AssignedTo = userTask.AssignedTo,
                AssignedUser = userDTO,
                DueDate = userTask.DueDate,
                Status = userTask.Status,
            };
        }

        public UserTaskReportDTO GetUserTaskReport() {
            var userTasks = _repository.GetAll();
            int totalTasks = 0;
            int pendingTasks = 0;
            int completedTasks = 0;
            var userTaskReportDTO = new UserTaskReportDTO {
                UserTaskDetails = new List<UserTaskDTO>()
            };
            foreach(var userTask in userTasks) {
                if(userTask.Status == UserTaskStatusEnum.Pending) {
                    pendingTasks++;
                }
                if(userTask.Status == UserTaskStatusEnum.Completed) {
                    completedTasks++;
                }
                totalTasks++;
                
                var userTaskDTO = new UserTaskDTO { 
                    Id=userTask.Id,
                    JobOrderId = userTask.JobOrderId,
                    JobOrder = _jobOrderService.GetJobOrderById(userTask.JobOrderId),
                    Title = userTask.Title,
                    Description = userTask.Description,
                    AssignedTo = userTask.AssignedTo,
                    AssignedUser = _userService.GetUserById(userTask.AssignedTo),
                    DueDate = userTask.DueDate,
                    Status = userTask.Status,
                };
                userTaskReportDTO.UserTaskDetails.Add(userTaskDTO);
            }
            userTaskReportDTO.CompletedTasks = completedTasks;
            userTaskReportDTO.PendingTasks = pendingTasks;
            userTaskReportDTO.TotalTasks = totalTasks;
            return userTaskReportDTO;
        }

        public void UpdateUserTask(UpdateUserTaskDTO userTaskDTO) {
            var user = _userService.GetUserById(userTaskDTO.AssignedTo);
            var jobOrderDTO = _jobOrderService.GetJobOrderById(userTaskDTO.JobOrderId);

            var userTask = _repository.GetById(userTaskDTO.Id);

            userTask.JobOrderId = userTaskDTO.JobOrderId;
            userTask.Title = userTaskDTO.Title;
            userTask.Description = userTaskDTO.Description;
            userTask.AssignedTo = userTaskDTO.AssignedTo;
            userTask.DueDate = userTaskDTO.DueDate;
            userTask.Status = userTaskDTO.Status;
            _repository.Update(userTask);
            var notification = _notificationService.GetNotificationByUserAndUserTaskId(user.Id,userTask.Id);
            _notificationService.CreateNotification(new CreateNotificationDTO {
                Message = "User Task with Id " + userTask.Id + " is updated!",
                UserId = userTaskDTO.AssignedTo,
                UserTaskId = userTask.Id,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
