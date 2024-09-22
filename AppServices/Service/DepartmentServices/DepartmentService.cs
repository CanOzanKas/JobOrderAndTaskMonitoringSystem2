using AppCore.Entities;
using AppPersistence.Repositories.GenericRepository;
using AppServices.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.DepartmentServices {
    public class DepartmentService:IDepartmentService {
        GenericRepository<Department> _repository;

        public DepartmentService(GenericRepository<Department> repository) { 
            _repository = repository;
        }

        public void CreateDepartment(CreateDepartmentDTO department) {
            _repository.Create(new Department {
                DepartmentName = department.DepartmentName,
            });
        }

        public void DeleteDepartment(DepartmentDTO department) {
            _repository.Delete(_repository.GetById(department.Id)); 
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments() {
            var departments = _repository.GetAll();
            return departments.Select(d => new DepartmentDTO { 
                Id = d.Id,
                DepartmentName = d.DepartmentName,
                Users = d.Users
            });
        }

        public DepartmentDTO GetDepartmentById(int id) {
            var department = _repository.GetById(id);
            return new DepartmentDTO() {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Users = department.Users
            };
        }

        public void UpdateDepartment(DepartmentDTO department) {
            _repository.Update(new Department {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Users = department.Users
            });
        }
    }
}
