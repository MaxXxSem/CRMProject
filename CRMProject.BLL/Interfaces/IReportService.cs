using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // Reports class
    interface IReportService
    {
        // get report related with managers
        IEnumerable<ManagersReportDTO> GetManagersReport();

        // get report related with transactions
        IEnumerable<TransactionDTO> GetTransactionsReport();
    }
}
