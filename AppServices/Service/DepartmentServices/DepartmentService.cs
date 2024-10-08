﻿using AppCore.Entities;
using AppPersistence.Repositories.GenericRepo;
using AppServices.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.DepartmentServices {
    public class DepartmentService:IDepartmentService {
        private readonly IGenericRepository<Department> _repository;

        public DepartmentService(IGenericRepository<Department> repository) { 
            _repository = repository;
        }
        public void CreateDepartment(CreateDepartmentDTO department) {
            _repository.Create(new Department {
                DepartmentName = department.DepartmentName
            });
        }
        public void DeleteDepartment(int id) {
            _repository.Delete(_repository.GetById(id)); 
        }
        public List<DepartmentDTO> GetAllDepartments() {
            var departments = _repository.GetAll();
            return departments.Select(d => new DepartmentDTO { 
                Id = d.Id,
                DepartmentName = d.DepartmentName
            }).ToList();
        }
        public DepartmentDTO GetDepartmentById(int id) {
            var department = _repository.GetById(id);
            
            return new DepartmentDTO() {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }
        public Department GetDepartmentEntityById(int id) { 
            return _repository.GetById(id);
        }
        public void UpdateDepartment(DepartmentDTO departmentDTO) {
            var department = _repository.GetById(departmentDTO.Id);
            department.DepartmentName = departmentDTO.DepartmentName;   
            _repository.Update(department);
        }
        public DepartmentDTO MapToDTO(Department department) {
            return new DepartmentDTO() {
                Id= department.Id,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
