using AppServices.DTOs.NotificationDTOs;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.NotificationServices {
    public interface INotificationService {
        public void CreateNotification(CreateNotificationDTO createNotificationDTO);
        public void UpdateNotification(NotificationDTO notificationDTO);
        public void DeleteNotification(int id);
        public List<NotificationDTO> GetAllNotificationsByUserId(int userId);
        public NotificationDTO GetNotificationById(int id);
    }
}
