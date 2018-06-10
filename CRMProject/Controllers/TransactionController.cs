using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CRMProject.BLL.Interfaces;
using CRMProject.Models.ViewModels;

namespace CRMProject.Controllers
{
    public class TransactionController : Controller
    {
        private ITransactionService service { get; set; }

        public TransactionController(ITransactionService transService)
        {
            service = transService;
        }

        // GET: Transaction
        public async Task<ActionResult> TransactionsList()
        {
            var transactions = await service.GetTransactions();
            List<TransactionBasicViewModel> viewTransactions = new List<TransactionBasicViewModel>();
            if (transactions != null && transactions.Count() > 0)
            {
                foreach (var trans in transactions)
                {
                    viewTransactions.Add(new TransactionBasicViewModel()
                    {
                        Id = trans.Id,
                        Date = trans.Date,
                        Description = trans.Description,
                        Sum = trans.Sum,
                        ResponsibleUserName = trans.ResponsibleUserName,
                        ClientName = trans.ClientName
                    });
                }
            }

            return View(viewTransactions);
        }
    }
}