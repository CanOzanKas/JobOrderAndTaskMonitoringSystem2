using AppCore.Entities;
using AppPersistence.Repositories.GenericRepo;
using AppServices.DTOs.NotificationDTOs;
using AppServices.Service.UserServices;
using AppServices.Service.UserTaskServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.NotificationServices {
    public class NotificationService:INotificationService {
        private readonly IGenericRepository<Notification> _repository;
        private readonly IUserService _userService;
        private readonly IUserTaskService _userTaskService;

        public NotificationService(IGenericRepository<Notification> repository, IUserService userService, IUserTaskService userTaskService) {
            _repository = repository;
            _userService = userService;
            _userTaskService = userTaskService;
        }

        public void CreateNotification(CreateNotificationDTO createNotificationDTO) {
            _repository.Create(new Notification { 
                Message = createNotificationDTO.Message,
                UserId = createNotificationDTO.UserId,
                UserTaskId = createNotificationDTO.UserTaskId,
                CreatedDate = createNotificationDTO.CreatedDate,
            });
        }

        public void DeleteNotification(int id) {
            _repository.Delete(_repository.GetById(id));    
        }

        public List<NotificationDTO> GetAllNotificationsByUserId(int userId) {
            var notifications = _repository.GetAll();
            return notifications.Where(n => n.UserId == userId).Select(n => new NotificationDTO {
                Id = n.Id,
                Message = n.Message,
                UserId = userId,
                User = _userService.GetUserById(userId),
                UserTaskId = n.UserTaskId,
                UserTask = _userTaskService.GetUserTaskById(n.UserTaskId),
                CreatedDate = n.CreatedDate,
            }).ToList();
        }

        public NotificationDTO GetNotificationById(int id) {
            var notification = _repository.GetById(id);
            return new NotificationDTO {
                Id = notification.Id,
                Message = notification.Message,
                UserId = notification.UserId,
                User = _userService.GetUserById(notification.UserId),
                UserTaskId = notification.UserTaskId,
                UserTask = _userTaskService.GetUserTaskById(notification.UserTaskId),
                CreatedDate = notification.CreatedDate,
            };
        }

        public NotificationDTO GetNotificationByUserAndUserTaskId(int userId,int userTaskId) {
            var notifications = _repository.GetAll();
            var notification = notifications
                .Where(n => n.UserTaskId == userTaskId && n.UserId == userId)
                .Select(n => GetNotificationById(n.Id)).ToList().First();
            return notification;
        }
        public void UpdateNotification(NotificationDTO notificationDTO) {
            var notification = _repository.GetById(notificationDTO.Id);
            notification.Message = notificationDTO.Message;
            notification.UserId = notificationDTO.UserId;
            notification.UserTaskId = notificationDTO.UserId;
            notification.CreatedDate = notificationDTO.CreatedDate;
            _repository.Update(notification);
        }
    }
}
