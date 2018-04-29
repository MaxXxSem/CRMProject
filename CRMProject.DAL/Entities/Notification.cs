namespace CRMProject.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(512)]
        public string Message { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
