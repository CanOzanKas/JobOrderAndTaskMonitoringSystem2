using AppCore.Entities;
using AppServices.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service.UserServices {
    public interface IUserService {
        public void CreateUser(CreateUserDTO user);
        public void UpdateUser(UserDTO user);
        public void DeleteUser(UserDTO user);
        public IEnumerable<UserDTO> GetAllUsers();
        public UserDTO GetUserById(int id);

    }
}
