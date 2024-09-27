using AppCore.Entities;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.UserServices {
    public interface IUserService {
        public void CreateUser(CreateUserDTO createUserDTO);
        public void UpdateUser(UserDTO userDTO);
        public void DeleteUser(int id);
        public List<UserDTO> GetAllUsers();
        public UserDTO GetUserById(int id);
        public List<UserDTO> GetAllUsersByDepartment(int departmentId);

        public UserDTO GetUserByEmail(string email);

    }
}
