using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // transaction operations
    interface ITransactionService
    {
        // get all transactions list
        IEnumerable<TransactionDTO> GetTransactions();

        // create new transaction
        bool AddTransaction(TransactionDTO trans);

        // get transaction info
        TransactionDTO GetTransactionData(int id);

        // update transaction info
        bool SetTransactionData(TransactionDTO trans);

        // add comment
        bool AddComment(int transId, string commentText);
    }
}
