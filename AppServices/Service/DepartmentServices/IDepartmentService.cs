using AppCore.Entities;
using AppServices.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.DepartmentServices {
    public interface IDepartmentService {

        public void CreateDepartment(CreateDepartmentDTO department);
        public void UpdateDepartment(DepartmentDTO departmentDTO);
        public void DeleteDepartment(int id);
        public List<DepartmentDTO> GetAllDepartments();
        public DepartmentDTO GetDepartmentById(int id);
        public Department GetDepartmentEntityById(int id);
        public DepartmentDTO MapToDTO(Department department);
    }
}
