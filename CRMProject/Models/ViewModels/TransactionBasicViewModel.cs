using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRMProject.Models.ViewModels
{
    public class TransactionBasicViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Sum { get; set; }
        public string ResponsibleUserName { get; set; }
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
    }
}