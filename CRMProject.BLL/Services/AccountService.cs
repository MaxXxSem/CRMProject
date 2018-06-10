using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Interfaces;
using CRMProject.DAL.Interfaces;
using CRMProject.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace CRMProject.BLL.Services
{
    public class AccountService : IAccount
    {
        IUnitOfWork Db { get; set; }

        public AccountService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Tasks.Task<UserDTO> GetUserData(int id)
        {
            var user = await Db.Users.Find(id);
            if (user != null)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserData.UserName
                };
            }
            else
            {
                return null;
            }
        }

        public async Tasks.Task SetUserData(UserDTO user)
        {
            try
            {
                var userEntity = await Db.Users.Find(user.Id);
                if (userEntity != null)
                {
                    if (!string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.NewPassword))
                    {
                        Db.UserManager.ChangePassword(userEntity.UserData.Id, user.Password, user.NewPassword);     //change user password
                    }

                    if (!string.IsNullOrEmpty(user.UserName))
                    {
                        userEntity.UserData.UserName = user.UserName;
                    }

                    await Db.Users.Update(userEntity);                        //update user info
                    Db.Save();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tasks.Task<ClaimsIdentity> SignIn(LoginDTO userData)
        {
            try
            {
                var user = Db.UserManager.Find(userData.Login, userData.Password);          // CAN'T FIND USER
                ClaimsIdentity claim = null;
                claim = Db.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                return Tasks.Task.FromResult(claim);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
