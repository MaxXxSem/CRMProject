using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.BLL.Services;
using CRMProject.DAL.Repositories;
using CRMProject.BLL.DTO;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public async Task SignIn()
        {
            LoginDTO login = new LoginDTO()
            {
                Login = "olololo",
                Password = "olololo"
            };

            var claim = await new AccountService(new UnitOfWork()).SignIn(login);
            Assert.IsNotNull(claim);
        }

        [TestMethod]
        public async Task SetGetUserData()
        {
            UserDTO userDto = new UserDTO()
            {
                Id = 3,
                UserName = "TestUserName",
                Password = "testPassword",
                NewPassword = "TestNewPassword"
            };

            var service = new AccountService(new UnitOfWork());
            await service.SetUserData(userDto);
            UserDTO user = await service.GetUserData(3);

            Assert.IsNotNull(user);
        }
    }
}
