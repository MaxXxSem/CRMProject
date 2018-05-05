using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CRMProject.DAL.Entities
{
    [Table("IdentityUserData")]
    public class IdentityUserData : IUser
    {
        public IdentityUserData()
        {
            Id = Guid.NewGuid().ToString();                 // generate new Id
            Roles = new HashSet<Role>();
        }

        [Key]
        public virtual string Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        [Required]
        [StringLength(64)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(64)]
        public string UserName { get; set; }

        public virtual string SecurityStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }

        public virtual User User { get; set; }
    }
}
