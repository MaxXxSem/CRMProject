using System;
using System.Collections.Generic;

namespace CRMProject.BLL.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int? ResponsibleUserId { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
    }
}
