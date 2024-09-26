﻿using AppCore.Entities;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.NotificationDTOs {
    public class NotificationDTO {
        public int Id { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public int TaskId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
