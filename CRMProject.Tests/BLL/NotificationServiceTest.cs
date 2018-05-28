using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.BLL.Services;
using CRMProject.DAL.Repositories;
using CRMProject.BLL.DTO;
using System.Linq;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class NotificationServiceTest
    {
        [TestMethod]
        public async Task AddNotification()
        {
            NotificationDTO notif = new NotificationDTO()
            {
                Message = "testMessage",
                Date = DateTime.Now,
                UserId = 3
            };

            bool result = await new NotificationService(new UnitOfWork()).AddNotification(notif);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetNotification()
        {
            NotificationDTO notif = await new NotificationService(new UnitOfWork()).GetNotification(1);
            Assert.IsNotNull(notif);
        }

        [TestMethod]
        public async Task GetUsersNotifications()
        {
            var notifications = await new NotificationService(new UnitOfWork()).GetUsersNotifications("d2644dea-aea0-4333-a08c-b66c286794df");
            Assert.IsTrue(notifications != null && notifications.Count() > 0);
        }
    }
}
