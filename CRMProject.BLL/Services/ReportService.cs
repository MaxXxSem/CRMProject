using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.BLL.Interfaces;
using CRMProject.DAL.Interfaces;
using CRMProject.BLL.DTO;
using CRMProject.DAL.Entities;

namespace CRMProject.BLL.Services
{
    class ReportService : IReportService
    {
        IUnitOfWork Db { get; set; }

        public ReportService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Tasks.Task<IEnumerable<ManagersReportDTO>> GetManagersReport()
        {
            List<ManagersReportDTO> report = new List<ManagersReportDTO>();
            var users = await Db.Users.Include(u => u.Transactions.Count != 0, u => u.Transactions);        // get all users and their transactions

            if (users != null)
            {
                foreach (var us in users)                                                                   // for each user
                {
                    var reportDto = new ManagersReportDTO()                                                 // create user's report
                    {
                        User = new UserDTO()
                        {
                            Id = us.Id,
                            UserName = us.UserData.UserName
                        },
                        Transactions = new List<TransactionDTO>()
                    };

                    foreach (var trans in us.Transactions)                                                  // add user's transactions to report
                    {
                        (reportDto.Transactions as List<TransactionDTO>).Add(new TransactionDTO()
                        {
                            Id = trans.Id,
                            Sum = trans.Sum,
                            Status = trans.Status
                        });
                    }

                    report.Add(reportDto);                                                                  // add report to reports list
                }

                return report;
            }

            return null;
        }

        // TODO: add date to transactions entity
        public Tasks.Task<IEnumerable<TransactionDTO>> GetTransactionsReport()
        {
            throw new NotImplementedException();
        }
    }
}
