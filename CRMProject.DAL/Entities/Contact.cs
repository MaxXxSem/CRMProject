namespace CRMProject.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public Contact()
        {
            Id = 0;         // default value
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string PhoneNumber { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public int? ClientId { get; set; }

        public int? TransactionId { get; set; }

        public int TypeId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
