using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // transaction operations
    public interface ITransactionService
    {
        // get all transactions list
        Task<IEnumerable<TransactionDTO>> GetTransactions();

        // create new transaction
        Task<bool> AddTransaction(TransactionDTO trans);

        // get transaction info
        Task<TransactionDTO> GetTransactionData(int id);

        // update transaction info
        Task<bool> SetTransactionData(TransactionDTO trans);

        // add comment
        Task<bool> AddComment(int transId, int typeId, string commentText, int userId);
    }
}
