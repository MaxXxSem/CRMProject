using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.Models.ViewModels
{
    public class TaskBasicViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string ResponsibleUserName { get; set; }
    }
}