using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.BLL.Interfaces;
using CRMProject.DAL.Interfaces;
using CRMProject.DAL.Entities;
using CRMProject.BLL.DTO;
using AutoMapper;

namespace CRMProject.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        IUnitOfWork Db { get; set; }

        public TransactionService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Tasks.Task<bool> AddTransaction(TransactionDTO trans)
        {
            if (trans != null)
            {
                Transaction transaction = new Transaction()
                {
                    Description = trans.Description,
                    Date = trans.Date,
                    Sum = trans.Sum,
                    Status = trans.Status
                };

                if (trans.ClientId.HasValue)
                    transaction.Client = await Db.Clients.Find(trans.ClientId.Value);

                if (trans.ResponsibleUserId.HasValue)
                    transaction.User = await Db.Users.Find(trans.ResponsibleUserId.Value);

                await Db.Transactions.Create(transaction);
                Db.Save();
                return true;
            }

            return false;
        }

        public async Tasks.Task<IEnumerable<TransactionDTO>> GetTransactions()
        {
            IEnumerable<Transaction> transactions = await Db.Transactions.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Transaction, TransactionDTO>());
            var transactionsDTO = Mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDTO>>(transactions);
            return transactionsDTO;
        }

        public async Tasks.Task<TransactionDTO> GetTransactionData(int id)
        {
            var transaction = await Db.Transactions.Find(id);

            if (transaction != null)
            {
                var comments = await Db.Comments.Get(c => c.TypeId == transaction.TypeId && c.CommentedEntityId == transaction.Id);
                Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());

                TransactionDTO transDTO = new TransactionDTO()
                {
                    Id = transaction.Id,
                    Date = transaction.Date,
                    Sum = transaction.Sum,
                    Status = transaction.Status,
                    Description = transaction.Description,
                    ClientId = transaction.ClientId,
                    ResponsibleUserId = transaction.ResponsibleUserId,
                    Comments = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments)
                };

                return transDTO;
            }

            return null;
        }

        public async Tasks.Task<bool> SetTransactionData(TransactionDTO trans)
        {
            if (trans != null)
            {
                var transEntity = await Db.Transactions.Find(trans.Id);

                if (transEntity != null)
                {
                    transEntity.Date = trans.Date;
                    transEntity.Description = trans.Description;
                    transEntity.Sum = trans.Sum;
                    transEntity.Status = trans.Status;
                    if (trans.ClientId.HasValue)
                        transEntity.Client = await Db.Clients.Find(trans.ClientId.Value);

                    if (trans.ResponsibleUserId.HasValue)
                        transEntity.User = await Db.Users.Find(trans.ResponsibleUserId.Value);

                    await Db.Transactions.Update(transEntity);
                    Db.Save();
                    return true;
                }
            }

            return false;
        }

        public async Tasks.Task<bool> AddComment(int transId, int typeId, string commentText, int userId)
        {
            if (string.IsNullOrEmpty(commentText))
            {
                return false;
            }

            try
            {
                Comment comment = new Comment()
                {
                    Text = commentText,
                    CommentedEntityId = transId,
                    TypeId = typeId,
                    User = await Db.Users.Find(userId)
                };

                await Db.Comments.Create(comment);
                Db.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
