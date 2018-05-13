using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // notifications operations
    interface INotificationsService
    {
        // create new notifications
        Task<bool> AddNotification(NotificationDTO notification);

        // get notification
        Task<NotificationDTO> GetNotification(int id);
    }
}
