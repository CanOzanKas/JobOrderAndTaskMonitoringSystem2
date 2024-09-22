﻿using AppCore.Entities;
using AppServices.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.DepartmentServices {
    public interface IDepartmentService {

        public void CreateDepartment(CreateDepartmentDTO department);
        public void UpdateDepartment(DepartmentDTO department);
        public void DeleteDepartment(int id);
        public IEnumerable<DepartmentDTO> GetAllDepartments();
        public DepartmentDTO GetDepartmentById(int id);
    }
}
