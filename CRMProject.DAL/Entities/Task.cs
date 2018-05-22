namespace CRMProject.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public int? ResponsibleUserId { get; set; }

        [Required]
        [StringLength(64)]
        public string Priority { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        [Required]
        [StringLength(64)]
        public string Status { get; set; }

        public int TypeId { get; set; }

        public virtual User User { get; set; }
    }

    public enum TaskStatus
    {
        Opened,
        Closed
    }
}
