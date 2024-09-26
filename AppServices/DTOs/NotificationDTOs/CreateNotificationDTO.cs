using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.NotificationDTOs {
    public class CreateNotificationDTO {
        public int Id { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }

        public int UserTaskId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
