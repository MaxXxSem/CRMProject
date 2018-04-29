namespace CRMProject.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Text { get; set; }

        public int? UserId { get; set; }

        public int TypeId { get; set; }

        public int CommentedEntityId { get; set; }

        public virtual User User { get; set; }
    }
}
