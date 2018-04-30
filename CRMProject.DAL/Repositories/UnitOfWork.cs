using System;
using System.Collections.Generic;
using System.Linq;
using CRMProject.DAL.Entities;
using CRMProject.DAL.Identity;
using CRMProject.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CRMProject.DAL.Repositories
{
    // IUnitOfWork implementation
    public class UnitOfWork : IUnitOfWork
    {
        private CRMEntities db;
        private IRepository<Client> clients;
        private IRepository<Comment> comments;
        private IRepository<Contact> contacts;
        private IRepository<Notification> notifications;
        private IRepository<Role> roles;
        private IRepository<Task> tasks;
        private IRepository<Transaction> transactions;
        private IRepository<User> users;
        private IRepository<IdentityUserData> usersData;
        private IdentityUserManager userManager;
        private IdentityRoleManager roleManager;

        public UnitOfWork()
        {
            db = new CRMEntities();
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clients == null)
                    clients = new BaseRepository<Client>(db);
                return clients;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (comments == null)
                    comments = new BaseRepository<Comment>(db);
                return comments;
            }
        }

        public IRepository<Contact> Contacts
        {
            get
            {
                if (contacts == null)
                    contacts = new BaseRepository<Contact>(db);
                return contacts;
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                if (notifications == null)
                    notifications = new BaseRepository<Notification>(db);
                return notifications;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roles == null)
                    roles = new BaseRepository<Role>(db);
                return roles;
            }
        }

        public IRepository<Task> Tasks
        {
            get
            {
                if (tasks == null)
                    tasks = new BaseRepository<Task>(db);
                return tasks;
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                if (transactions == null)
                    transactions = new BaseRepository<Transaction>(db);
                return transactions;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (users == null)
                    users = new BaseRepository<User>(db);
                return users;
            }
        }

        public IRepository<IdentityUserData> UsersData
        {
            get
            {
                if (usersData == null)
                    usersData = new BaseRepository<IdentityUserData>(db);
                return usersData;
            }
        }

        public IdentityUserManager UserManager
        {
            get
            {
                if (userManager == null)
                    userManager = new IdentityUserManager(new IdentityUserStore(db));
                return userManager;
            }
        }

        public IdentityRoleManager RoleManager
        {
            get
            {
                if (roleManager == null)
                    roleManager = new IdentityRoleManager(new RoleStore<Role>(db));
                return roleManager;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }

        // save changes
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
