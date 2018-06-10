using System;
using System.Linq;
using CRMProject.DAL.Entities;
using CRMProject.DAL.Identity;

namespace CRMProject.DAL.Interfaces
{
    // access to repositories
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<Role> Roles { get; }
        IRepository<Task> Tasks { get; }
        IRepository<Transaction> Transactions { get; }
        IRepository<User> Users { get; }
        IRepository<IdentityUserData> UsersData { get; }
        //IRepository<EntityPopularityStat> EntitiesStat { get; }
        IdentityUserManager UserManager { get; }
        IdentityRoleManager RoleManager { get; }

        // save changes
        void Save();
    }
}
