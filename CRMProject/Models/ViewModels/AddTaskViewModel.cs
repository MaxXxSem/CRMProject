using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRMProject.Models.ViewModels
{
    public class AddTaskViewModel
    {
        public string Title { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd  hh:mm:ss tt}}")]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }

        public string Description { get; set; }
        public string Priority { get; set; }
        public int? ResponsibleUserId { get; set; }
    }
}