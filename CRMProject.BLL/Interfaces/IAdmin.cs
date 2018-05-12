using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;
using System.Threading.Tasks;

namespace CRMProject.BLL.Interfaces
{
    // administrator's functions
    public interface IAdmin
    {
        // all users list
        Task<IEnumerable<UserDTO>> GetUsers();

        // create new user
        Task<bool> CreateUser(RegistrationDTO userData);

        // delete user
        Task<bool> DeleteUser(string identityUserId);

        // add user to role
        Task<bool> SetUserRole(string identityUserId, string roleName);

        // remove user from role
        Task<bool> RemoveUserRole(string identityUserId, string roleName);
    }
}