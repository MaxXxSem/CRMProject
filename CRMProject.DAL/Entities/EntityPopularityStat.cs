//namespace CRMProject.DAL.Entities
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("EntityPopularityStat")]
//    public partial class EntityPopularityStat
//    {
//        public int Id { get; set; }

//        [Column(TypeName = "datetime2")]
//        public DateTime Date { get; set; }

//        public int ClicksCount { get; set; }

//        public int UserId { get; set; }

//        public int EntityId { get; set; }

//        public int TypeId { get; set; }

//        public virtual User User { get; set; }
//    }
//}
