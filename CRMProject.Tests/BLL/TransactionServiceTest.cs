using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.DAL.Repositories;
using CRMProject.BLL.Services;
using CRMProject.BLL.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class TransactionServiceTest
    {
        [TestMethod]
        public async Task GetTransactions()
        {
            var trans = await new TransactionService(new UnitOfWork()).GetTransactions();
            Assert.IsTrue(trans != null && trans.Count() > 0);
        }

        [TestMethod]
        public async Task AddTransaction()
        {
            TransactionDTO trans = new TransactionDTO()
            {
                Date = DateTime.Now,
                Description = "testDescr",
                Status = "safasfs",
                ResponsibleUserId = 3,
                Sum = 13.0M
            };

            bool result = await new TransactionService(new UnitOfWork()).AddTransaction(trans);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetTransactionData()
        {
            TransactionDTO trans = await new TransactionService(new UnitOfWork()).GetTransactionData(1027);
            Assert.IsNotNull(trans);
        }

        [TestMethod]
        public async Task SetTransactionData()
        {
            TransactionDTO trans = new TransactionDTO()
            {
                Id = 1027,
                Date = DateTime.Now,
                Description = "new",
                Status = "new",
                ResponsibleUserId = 3,
                Sum = 13.0M,
                ClientId = null
            };

            bool result = await new TransactionService(new UnitOfWork()).SetTransactionData(trans);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task AddComment()
        {
            bool result = await new TransactionService(new UnitOfWork()).AddComment(1027, 2, "TransactionComment", 3);
            Assert.IsTrue(result);
        }
    }
}
