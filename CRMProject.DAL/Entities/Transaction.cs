namespace CRMProject.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            Id = 0;                                     // default value
            Contacts = new HashSet<Contact>();
            Date = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Sum { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int? ResponsibleUserId { get; set; }

        public int? ClientId { get; set; }

        [Required]
        [StringLength(64)]
        public string Status { get; set; }

        public int TypeId { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual User User { get; set; }
    }
}
