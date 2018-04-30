using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CRMProject.DAL.Entities;
using Microsoft.Owin;

namespace CRMProject.DAL.Identity
{
    public class IdentityUserManager : UserManager<IdentityUserData>
    {
        public IdentityUserManager(IUserStore<IdentityUserData> store) : base(store) { }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            var manager = new IdentityUserManager(new IdentityUserStore(context.Get<CRMEntities>()));

            manager.UserValidator = new UserValidator<IdentityUserData>(manager)            // set user validator
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator()                             // set password validator
            {
                RequireDigit = false,
                RequiredLength = 6,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            return manager;
        }
    }
}
