using AppCore.Entities;
using AppPersistence.Repositories.GenericRepository;
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

        public void CreateDepartment(DepartmentDTO department) {
            _repository.Create(department);

        }

        public void DeleteDepartment(DepartmentDTO department) {
            _repository.Delete(department);
        }

        public IEnumerable<Department> GetAllDepartments() {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id) {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department entity) {
            throw new NotImplementedException();
        }
    }
}
