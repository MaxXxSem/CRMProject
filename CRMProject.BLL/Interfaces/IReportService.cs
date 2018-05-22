using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // Reports class
    interface IReportService
    {
        // get report related with managers
        Task<IEnumerable<ManagersReportDTO>> GetManagersReport();

        // get report related with transactions
        Task<IEnumerable<TransactionsReportDTO>> GetTransactionsReport();
    }
}
