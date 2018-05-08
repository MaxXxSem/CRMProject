using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Interfaces;
using CRMProject.DAL.Interfaces;

namespace CRMProject.BLL.Services
{
    public class Account : IAccount
    {
        IUnitOfWork Db { get; set; }

        public Account(IUnitOfWork uow)
        {
            Db = uow;
        }

        public UserDTO GetUserData(int id)
        {
            var user = Db.Users.Find(id);
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

        public void SetUserData(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public ClaimsIdentity SignIn(LoginDTO userData)
        {
            throw new NotImplementedException();
        }
    }
}
