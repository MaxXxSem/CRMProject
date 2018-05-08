using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BLL.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
        public int ResponsibleUserId { get; set; }
    }
}
