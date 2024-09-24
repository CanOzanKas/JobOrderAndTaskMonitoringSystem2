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
            throw new NotImplementedException();
        }

        public void DeleteNotification(int id) {
            throw new NotImplementedException();
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
