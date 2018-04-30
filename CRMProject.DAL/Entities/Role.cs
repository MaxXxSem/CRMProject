namespace CRMProject.DAL.Entities
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // identity roles
    [Table("Role")]
    public partial class Role : IdentityRole
    {
        public Role()
        {
            Users = new HashSet<IdentityUserData>();
        }
        
        public new ICollection<IdentityUserData> Users { get; set; }
    }
}
