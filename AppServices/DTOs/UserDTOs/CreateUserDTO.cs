using AppCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Entities;

namespace AppServices.DTOs.UserDTOs {
    public class CreateUserDTO {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
