using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BLL.DTO
{
    // Contains user and user's transactions
    public class ManagersReportDTO
    {
        public UserDTO User { get; set; }
        public IEnumerable<TransactionDTO> Transactions { get; set; }
    }
}
