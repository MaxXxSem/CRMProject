using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Interfaces;
using CRMProject.DAL.Interfaces;
using CRMProject.DAL.Entities;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace CRMProject.BLL.Services
{
    class AdminService : IAdmin
    {
        IUnitOfWork Db { get; set; }

        public AdminService(IUnitOfWork uof)
        {
            Db = uof;
        }

        public async Tasks.Task<bool> CreateUser(RegistrationDTO userData)
        {
            var user = await Db.UserManager.FindByEmailAsync(userData.Email);
            if (user == null)
            {
                user = new IdentityUserData()                                               // create new user
                {
                    Email = userData.Email,
                    EmailConfirmed = false,
                    UserName = userData.UserName
                };

                var result = await Db.UserManager.CreateAsync(user, userData.Password);
                if (result.Errors.Count() > 0)
                {
                    return false;
                }

                await Db.UserManager.AddToRoleAsync(user.Id, userData.RoleName);            // set initial user's role
                await Db.Users.Create(new User()                                            // create new user entity
                {
                    DateOfBirth = userData.DateOfBirth,
                    UserData = user
                });
                Db.Save();                                                                  // save changes
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Tasks.Task<bool> DeleteUser(string identityUserId)
        {
            var user = await Db.UserManager.FindByIdAsync(identityUserId);
            if (user != null)
            {
                var result = await Db.UserManager.DeleteAsync(user);
                if (result == IdentityResult.Success)
                {
                    return true;
                }
            }

            return false;
        }

        public async Tasks.Task<IEnumerable<UserDTO>> GetUsers()
        {
            IEnumerable<User> users = await Db.Users.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>()
                .ForMember("Id", opt => opt.MapFrom(u => u.Id))
                .ForMember("UserName", opt => opt.MapFrom(u => u.UserData.UserName)));
            var usersDTO = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public Tasks.Task<bool> SetUserRole(string identityUserId, string roleName)
        {
            var result = Db.UserManager.AddToRole(identityUserId, roleName);
            if (result == IdentityResult.Success)
            {
                return Tasks.Task.FromResult(true);
            }

            return Tasks.Task.FromResult(false);
        }

        public Tasks.Task<bool> RemoveUserRole(string identityUserId, string roleName)
        {
            var result = Db.UserManager.RemoveFromRole(identityUserId, roleName);
            if (result == IdentityResult.Success)
            {
                return Tasks.Task.FromResult(true);
            }

            return Tasks.Task.FromResult(false);
        }
    }
}
