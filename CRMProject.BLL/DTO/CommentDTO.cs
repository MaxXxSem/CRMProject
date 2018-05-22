using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public int TypeId { get; set; }
        public int CommentedEntityId { get; set; }
    }
}
