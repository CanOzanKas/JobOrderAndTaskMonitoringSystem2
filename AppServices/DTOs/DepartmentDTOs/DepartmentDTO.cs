using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Entities;

namespace AppServices.DTOs.DepartmentDTOs {
    public class DepartmentDTO {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
