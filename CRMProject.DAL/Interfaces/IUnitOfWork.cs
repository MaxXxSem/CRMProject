using System;
using System.Linq;
using CRMProject.DAL.Entities;

namespace CRMProject.DAL.Interfaces
{
    // access to repositories
    interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<Role> Roles { get; }
        IRepository<Task> Tasks { get; }
        IRepository<Transaction> Transactions { get; }
        IRepository<User> Users { get; }

        // save changes
        void Save();
    }
}
