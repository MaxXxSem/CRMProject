using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMProject.Models.ViewModels
{
    public class AddClientViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
        public string Description { get; set; }
    }
}