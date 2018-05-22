using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BLL.DTO
{
    public class TransactionsReportDTO
    {
        // transactions date
        public DateTime Date { get; set; }

        // transactions count
        public int Count { get; set; }

        // transactions sum
        public decimal Sum { get; set; }
    }
}
