using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using CRMProject.DAL.Entities;

namespace CRMProject.DAL.Identity
{
    public class IdentityRoleManager : RoleManager<Role>
    {
        public IdentityRoleManager(IQueryableRoleStore<Role, string> store) : base(store) { }

        public static IdentityRoleManager Create(IdentityFactoryOptions<IdentityRoleManager> options, IOwinContext context)
        {
            return new IdentityRoleManager(new RoleStore<Role>(context.Get<CRMEntities>()));
        }
    }
}
