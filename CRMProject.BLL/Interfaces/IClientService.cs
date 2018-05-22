using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Infrastructure;

namespace CRMProject.BLL.Interfaces
{
    // clients operations
    public interface IClientService
    {
        // get all clients list
        Task<IEnumerable<ClientDTO>> GetClients();

        // add new client
        Task<bool> AddClient(ClientDTO client);

        // get client's info
        Task<ClientDTO> GetClientData(int id);

        // update client's info
        Task<bool> SetClientData(ClientDTO client);

        // delete client
        Task<bool> DeleteClient(int id);

        // get transactions related with client
        Task<IEnumerable<TransactionDTO>> GetTransactions(int clientId);

        // get contacts related with client
        Task<IEnumerable<ContactDTO>> GetContacts(int clientId);

        // send email to client
        Task<bool> SendEmail(Email email);

        // add comment
        Task<bool> AddComment(int clientId, int typeId, string commentText, int userId);
    }
}
