using AppCore.Entities;
using AppPersistence.Repositories.GenericRepo;
using AppServices.DTOs.UserDTOs;
using AppServices.Service.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.UserServices {
    public class UserService:IUserService {

        private readonly IGenericRepository<User> _repository;


        public UserService(IGenericRepository<User> repository, IDepartmentService departmentService) { 
            _repository = repository;
        }

        public void CreateUser(CreateUserDTO userDTO) {
            var user = new User {
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                Email = userDTO.Email,
                PasswordHash = userDTO.PasswordHash,
                Role = userDTO.Role,
                CreatedDate = userDTO.CreatedDate,
                DepartmentId = userDTO.DepartmentId
            };
            _repository.Create(user);
        }

        public void DeleteUser(int id) {
            _repository.Delete(_repository.GetById(id));
        }

        public List<UserDTO> GetAllUsers() {
            var users = _repository.GetAll();
            return users.Select(user => new UserDTO { 
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Role = user.Role,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                DepartmentId= user.DepartmentId
            }).ToList();
        }

        public List<UserDTO> GetAllUsersByDepartment(int departmentId) {
            var users = _repository.GetAll();
            return users.Where(u => u.DepartmentId == departmentId).Select(user => new UserDTO {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Role = user.Role,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                DepartmentId = user.DepartmentId
            }).ToList();
        }

        public UserDTO GetUserById(int id) {
            User user = _repository.GetById(id);
            return new UserDTO {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Role = user.Role,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                DepartmentId = user.DepartmentId
            };
        }

        public void UpdateUser(UserDTO userDTO) {
            var user = _repository.GetById(userDTO.Id);
            user.Name = userDTO.Name;
            user.Surname = userDTO.Surname;
            user.Email = userDTO.Email;
            user.Role = userDTO.Role;
            user.CreatedDate = userDTO.CreatedDate;
            user.UpdatedDate = userDTO.UpdatedDate;
            user.DepartmentId = userDTO.DepartmentId;
            _repository.Update(user);
        }
    }
}
