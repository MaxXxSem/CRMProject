using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // notifications operations
    interface INotificationsService
    {
        // create new notifications
        bool AddNotification(NotificationDTO notification);

        // get notification
        NotificationDTO GetNotification(int id);
    }
}
