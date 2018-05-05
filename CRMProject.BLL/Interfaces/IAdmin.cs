using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    public interface IAdmin
    {
        IEnumerable<UserDTO> GetUsers();
        void CreateUser(RegistrationDTO userData);
        void DeleteUser(int userId);
        void SetUserRole(int userId, string roleName);
    }
}
