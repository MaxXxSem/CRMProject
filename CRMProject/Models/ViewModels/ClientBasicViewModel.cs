using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.Models.ViewModels
{
    public class ClientBasicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Site { get; set; }
    }
}