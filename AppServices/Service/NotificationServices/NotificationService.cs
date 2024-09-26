using AppCore.Entities;
using AppPersistence.Repositories.GenericRepo;
using AppServices.DTOs.NotificationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.NotificationServices {
    public class NotificationService:INotificationService {
        private readonly IGenericRepository<Notification> _repository;

        public NotificationService(IGenericRepository<Notification> repository) {
            _repository = repository;
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
            throw new NotImplementedException();
        }

        public NotificationDTO GetNotificationById(int id) {
            throw new NotImplementedException();
        }

        public void UpdateNotification(NotificationDTO notificationDTO) {
            throw new NotImplementedException();
        }
    }
}
