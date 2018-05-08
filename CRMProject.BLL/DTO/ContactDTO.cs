using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BLL.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Desctiption { get; set; }
        public int ClientId { get; set; }
        public int TransactionId { get; set; }
    }
}
