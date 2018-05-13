using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.BLL.Interfaces;
using CRMProject.DAL.Interfaces;
using CRMProject.BLL.DTO;
using CRMProject.DAL.Entities;

namespace CRMProject.BLL.Services
{
    class NotificationService : INotificationsService
    {
        IUnitOfWork Db { get; set; }

        public NotificationService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Tasks.Task<bool> AddNotification(NotificationDTO notification)
        {
            if (notification == null)
            {
                return false;
            }

            Notification notificationEntity = new Notification()
            {
                Date = notification.Date,
                Message = notification.Message,
                User = await Db.Users.Find(notification.UserId)
            };

            await Db.Notifications.Create(notificationEntity);
            Db.Save();
            return true;
        }

        public async Tasks.Task<NotificationDTO> GetNotification(int id)
        {
            var notification = await Db.Notifications.Find(id);
            if (notification != null)
            {
                NotificationDTO dto = new NotificationDTO()
                {
                    Id = notification.Id,
                    Date = notification.Date,
                    Message = notification.Message,
                    UserId = notification.User.Id
                };

                return dto;
            }
            else
            {
                return null;
            }
        }
    }
}
