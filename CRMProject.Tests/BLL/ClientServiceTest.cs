using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.DAL.Repositories;
using CRMProject.BLL.Services;
using CRMProject.BLL.DTO;
using System.Linq;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class ClientServiceTest
    {
        [TestMethod]
        public async Task GetClients()
        {
            var clients = await new ClientService(new UnitOfWork()).GetClients();
            Assert.IsTrue(clients != null && clients.Count() > 0);
        }

        [TestMethod]
        public async Task AddClient()
        {
            ClientDTO client = new ClientDTO()
            {
                Id = 0,
                Address = "TestAddress",
                Description = "TestDescr",
                Email = "testemail@mail.com",
                Name = "TestName",
                PhoneNumber = "09721498012",
                Site = "www.test.com"
            };

            bool result = await new ClientService(new UnitOfWork()).AddClient(client);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetClientData()
        {
            var clientData = await new ClientService(new UnitOfWork()).GetClientData(1024);
            Assert.IsNotNull(clientData);
        }

        [TestMethod]
        public async Task SetClientData()
        {
            ClientDTO client = new ClientDTO()
            {
                Id = 1024,
                Address = "UpdatedTestAddress",
                Description = "UpdatedTestDescr",
                Email = "testemail@mail.com",
                Name = "TestName",
                PhoneNumber = "09721498012",
                Site = "www.test.com"
            };

            bool result = await new ClientService(new UnitOfWork()).SetClientData(client);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteClient()
        {
            bool result = await new ClientService(new UnitOfWork()).DeleteClient(1009);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetTransactions()
        {
            var trans = await new ClientService(new UnitOfWork()).GetTransactions(1024);
            Assert.IsTrue(trans != null && trans.Count() > 0);
        }

        [TestMethod]
        public async Task GetContacts()
        {
            var cont = await new ClientService(new UnitOfWork()).GetContacts(1024);
            Assert.IsTrue(cont != null && cont.Count() > 0);
        }

        [TestMethod]
        public async Task AddComment()
        {
            bool result = await new ClientService(new UnitOfWork()).AddComment(1024, 1, "commentTExt", 3);
            Assert.IsTrue(result);
        }
    }
}
