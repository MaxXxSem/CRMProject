using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.DAL.Repositories;
using CRMProject.DAL.Entities;
using System.Linq;

namespace CRMProject.Tests.DAL
{
    [TestClass]
    public class RepositoryTest
    {
        private UnitOfWork uof = new UnitOfWork();

        // Create/GetAll methods test
        [TestMethod]
        public void CreateTest()
        {
            uof.Users.Create(new User()
            {
                Id = 0,
                Email = "Email",
                Name = "Name",
                DateOfBirth = DateTime.Now,
                HireDate = DateTime.Now,
                Password = "password"
            });

            uof.Transactions.Create(new Transaction()
            {
                Id = 0,
                Description = "Description",
                Status = "Status",
                Sum = 1.1M                
            });

            uof.Save();

            var users = uof.Users.GetAll();
            var trans = uof.Transactions.GetAll();
            Assert.IsNotNull(users);
            Assert.IsNotNull(trans);
        }

        // Update method test
        [TestMethod]
        public void UpdateTest()
        {
            var client = uof.Clients.GetAll().First();
            client.Name = "UpdatedName";
            uof.Clients.Update(client);
            uof.Save();

            var newClient = uof.Clients.GetAll().First();

            Assert.AreEqual("UpdatedName", newClient.Name);
        }

        // Deleting test
        [TestMethod]
        public void DeleteTest()
        {
            var task = uof.Tasks.GetAll().First();
            uof.Tasks.Delete(task);
            uof.Save();

            var tasks = uof.Tasks.GetAll();

            Assert.IsTrue(tasks.Count() == 0);
        }

        // Find method test
        [TestMethod]
        public void FindTest()
        {
            var client = uof.Clients.Find(1009);
            Assert.IsNotNull(client);
        }

        // Get method test
        [TestMethod]
        public void GetTest()
        {
            var client = uof.Clients.Get(c => c.PhoneNumber == "Number").First();
            Assert.IsNotNull(client);
        }

        // Include method with 1 parameter
        [TestMethod]
        public void IncludeTest()
        {
            var tran = uof.Transactions.Include(c => c.User).First();
            var tran1 = uof.Transactions.Include(t => t.User.Id == 0, c => c.User).First();
            Assert.IsNotNull(tran.User);
            Assert.IsNotNull(tran1.User);
        }
    }
}
