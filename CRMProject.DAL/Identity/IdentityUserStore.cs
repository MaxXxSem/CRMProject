using System;
using Microsoft.AspNet.Identity;
using CRMProject.DAL.Entities;
using Tasks = System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Data.Entity;

namespace CRMProject.DAL.Identity
{
    // interaction with user's data in database
    public class IdentityUserStore : IUserStore<IdentityUserData>, IUserPasswordStore<IdentityUserData>, IUserSecurityStampStore<IdentityUserData>, IUserRoleStore<IdentityUserData>, IUserEmailStore<IdentityUserData>
    {
        // use standard UserStore for some operations
        private UserStore<IdentityUser> userStore;

        // get EF context
        private CRMEntities Db
        {
            get { return userStore.Context as CRMEntities; }
        }

        public IdentityUserStore(CRMEntities entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("", "Data context can't be null");
            }

            userStore = new UserStore<IdentityUser>(entities);
        }

        // add user to role
        public Tasks.Task AddToRoleAsync(IdentityUserData user, string roleName)
        {
            if (user == null || string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("AddToRoleAsync", "Parameter can't be null");
            }

            var role = Db.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            if (role != null && !user.Roles.Any(r => r.Name == roleName))
            {
                user.Roles.Add(role);
                Db.Entry(user).State = EntityState.Modified;
                return Db.SaveChangesAsync();
            }

            return Tasks.Task.FromResult(0);
        }

        // get user's roles
        public Tasks.Task<IList<string>> GetRolesAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("GetRolesAsync", "Parameter can't be null");
            }

            IList<string> roles = user.Roles.Select(r => r.Name).ToList();
            return Tasks.Task.FromResult(roles);
        }

        // check if user is in certain role
        public Tasks.Task<bool> IsInRoleAsync(IdentityUserData user, string roleName)
        {
            if (user == null || string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("IsInRoleAsync", "Parameter can't be null");
            }

            bool result = user.Roles.Any(r => r.Name == roleName);
            return Tasks.Task.FromResult(result);
        }

        // remove user from role
        public Tasks.Task RemoveFromRoleAsync(IdentityUserData user, string roleName)
        {
            if (user == null || string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("RemoveFromRoleAsync", "Parameter can't be null");
            }

            var role = Db.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            if (role != null && user.Roles.Contains(role))
            {
                user.Roles.Remove(role);
                return Db.SaveChangesAsync();
            }

            return Tasks.Task.FromResult(0);
        }

        // create identity user
        public Tasks.Task CreateAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("CreateAsync", "Parameter can't be null");
            }

            Db.UserData.Add(user);
            return Db.SaveChangesAsync();
        }

        // delete user account
        public Tasks.Task DeleteAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("DeleteAsync", "Parameter can't be null");
            }

            Db.UserData.Remove(user);
            return Db.SaveChangesAsync();
        }

        // update user data
        public Tasks.Task UpdateAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("UpdateAsync", "Parameter can't be null");
            }

            Db.Entry(user).State = EntityState.Modified;
            return Db.SaveChangesAsync();
        }

        // find user by email
        public Tasks.Task<IdentityUserData> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("FindByEmailAsync", "Parameter can't be null");
            }

            return Db.UserData.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        // find user by id
        public Tasks.Task<IdentityUserData> FindByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("FindByIdAsync", "Parameter can't be null");
            }

            return Db.UserData.FindAsync(userId);
        }

        // find user by name
        public Tasks.Task<IdentityUserData> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("FindByNameAsync", "Parameter can't be null");
            }

            return Db.UserData.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        }

        // get user's password hash
        public Tasks.Task<string> GetPasswordHashAsync(IdentityUserData user)
        {
            var password = user?.PasswordHash;
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("GetPasswordHashAsync", "Parameter or password value can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.GetPasswordHashAsync(identityUser);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // check if user has a password
        public Tasks.Task<bool> HasPasswordAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("HasPasswordAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.HasPasswordAsync(identityUser);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // set user's password
        public Tasks.Task SetPasswordHashAsync(IdentityUserData user, string passwordHash)
        {
            if (user == null || string.IsNullOrEmpty(passwordHash))
            {
                throw new ArgumentNullException("HasPasswordAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.SetPasswordHashAsync(identityUser, passwordHash);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // get user email
        public Tasks.Task<string> GetEmailAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("GetEmailAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.GetEmailAsync(identityUser);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // set user's email
        public Tasks.Task SetEmailAsync(IdentityUserData user, string email)
        {
            if (user == null || string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("SetEmailAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.SetEmailAsync(identityUser, email);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // get EmailConfirmed
        public Tasks.Task<bool> GetEmailConfirmedAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("GetEmailConfirmedAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.GetEmailConfirmedAsync(identityUser);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // set email confirmed
        public Tasks.Task SetEmailConfirmedAsync(IdentityUserData user, bool confirmed)
        {
            if (user == null)
            {
                throw new ArgumentNullException("SetEmailConfirmedAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.SetEmailConfirmedAsync(identityUser, confirmed);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // get security stamp
        public Tasks.Task<string> GetSecurityStampAsync(IdentityUserData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("GetSecurityStampAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.GetSecurityStampAsync(identityUser);
            SetIdentityUserData(user, identityUser);
            return task;
        }

        // set security stamp
        public Tasks.Task SetSecurityStampAsync(IdentityUserData user, string stamp)
        {
            if (user == null || string.IsNullOrEmpty(stamp))
            {
                throw new ArgumentNullException("SetSecurityStampAsync", "Parameter can't be null");
            }

            var identityUser = ToIdentityUser(user);
            var task = userStore.SetSecurityStampAsync(identityUser, stamp);
            SetIdentityUserData(user, identityUser);
            return task;
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
                    userStore.Dispose();
                }

                disposed = true;
            }
        }

        // set IdentityUserData entity
        private static void SetIdentityUserData(IdentityUserData user, IdentityUser identityUser)
        {
            user.PasswordHash = identityUser.PasswordHash;
            user.SecurityStamp = identityUser.SecurityStamp;
            user.Id = identityUser.Id;
            user.UserName = identityUser.UserName;
            user.Email = identityUser.Email;
            user.EmailConfirmed = identityUser.EmailConfirmed;
        }

        // get IdentityUser
        private IdentityUser ToIdentityUser(IdentityUserData user)
        {
            return new IdentityUser
            {
                Id = user.Id,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed
            };
        }
    }
}
