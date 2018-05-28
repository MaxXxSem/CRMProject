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
    public class ContactServiceTest
    {
        [TestMethod]
        public async Task AddContact()
        {
            ContactDTO contact = new ContactDTO()
            {
                Desctiption = "testDescr",
                Email = "testEmail",
                Name = "testContactName",
                PhoneNumber = "98237093"
            };

            bool result = await new ContactService(new UnitOfWork()).AddContact(contact);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteContact()
        {
            bool result = await new ContactService(new UnitOfWork()).DeleteContact(1028);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetContactData()
        {
            var contact = await new ContactService(new UnitOfWork()).GetContactData(1026);
            Assert.IsNotNull(contact);
        }

        [TestMethod]
        public async Task SetContactData()
        {
            ContactDTO contact = new ContactDTO()
            {
                Id = 1026,
                Desctiption = "testDescr",
                Email = "testEmail",
                Name = "testContactName",
                PhoneNumber = "98237093",
                ClientId = 1024,
                TransactionId = 1027
            };

            bool result = await new ContactService(new UnitOfWork()).SetContactData(contact);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetContacts()
        {
            var contacts = await new ContactService(new UnitOfWork()).GetContacts();
            Assert.IsTrue(contacts != null && contacts.Count() > 0);
        }

        [TestMethod]
        public async Task AddComment()
        {
            bool result = await new ContactService(new UnitOfWork()).AddComment(1026, 3, "ContactComment", 3);
            Assert.IsTrue(result);
        }
    }
}
