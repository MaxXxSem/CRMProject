using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.DAL.Repositories;
using CRMProject.BLL.Services;
using CRMProject.BLL.DTO;
using System.Threading.Tasks;
using System.Linq;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class AdminServiceTest
    {
        [TestMethod]
        public async Task GetUsers()
        {
            var users = await new AdminService(new UnitOfWork()).GetUsers();
            Assert.IsTrue(users != null && users.Count() > 0);
        }

        [TestMethod]
        public async Task CreateUser()
        {
            RegistrationDTO registration = new RegistrationDTO()
            {
                Email = "olololo@mail.com",
                UserName = "olololo",
                Password = "olololo",
                DateOfBirth = new DateTime(2000, 5, 3),
                RoleName = "user"
            };

            bool result = await new AdminService(new UnitOfWork()).CreateUser(registration);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            bool result = await new AdminService(new UnitOfWork()).DeleteUser("3");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task SetUserRole()
        {
            bool result = await new AdminService(new UnitOfWork()).SetUserRole("1", "admin");
            bool isInRole = await new UnitOfWork().UserManager.IsInRoleAsync("1", "admin");
            Assert.IsTrue(isInRole);
        }

        [TestMethod]
        public async Task RemoveUserRole()
        {
            bool result = await new AdminService(new UnitOfWork()).RemoveUserRole("1", "admin");
            bool isInRole = await new UnitOfWork().UserManager.IsInRoleAsync("1", "admin");
            Assert.IsFalse(isInRole);
        }
    }
}
