using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // Account operations
    public interface IAccount
    {
        // sign in
        Task<ClaimsIdentity> SignIn(LoginDTO userData);

        // get user's info
        Task<UserDTO> GetUserData(int id);

        // update user's info
        Task SetUserData(UserDTO user);
    }
}
