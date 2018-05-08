using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // administrator's functions
    public interface IAdmin
    {
        // all users list
        IEnumerable<UserDTO> GetUsers();

        // create new user
        bool CreateUser(RegistrationDTO userData);

        // delete user
        bool DeleteUser(int userId);

        // add user to role
        bool SetUserRole(int userId, string roleName);
    }
}