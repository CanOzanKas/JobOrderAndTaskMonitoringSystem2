using AppCore.Entities;
using AppPersistence.Context;
using AppPersistence.Repositories.GenericRepository;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.UserServices {
    public class UserService:IUserService {

        private readonly GenericRepository<User> _repository;

        public UserService(GenericRepository<User> repository) { 
            _repository = repository;
        }

        public void CreateUser(CreateUserDTO user) {
            _repository.Create(new User {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
                CreatedDate = user.CreatedDate,
                Department = user.Department
            });
        }

        public void DeleteUser(UserDTO user) {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUsers() {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id) {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDTO user) {
            throw new NotImplementedException();
        }
    }
}
