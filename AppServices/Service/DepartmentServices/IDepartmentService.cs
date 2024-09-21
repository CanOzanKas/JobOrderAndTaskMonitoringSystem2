using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.DepartmentServices {
    public interface IDepartmentService {

        public void CreateDepartment(Department department);
        public void UpdateDepartment(Department entity);
        public void DeleteDepartment(Department entity);
        public IEnumerable<Department> GetAllDepartments();
        public Department GetDepartmentById(int id);
    }
}
