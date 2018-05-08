using System;
using System.Collections.Generic;
using System.Security.Claims;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // Account operations
    public interface IAccount
    {
        // sign in
        ClaimsIdentity SignIn(LoginDTO userData);

        // get user's info
        UserDTO GetUserData(int id);

        // update user's info
        void SetUserData(UserDTO user);
    }
}
