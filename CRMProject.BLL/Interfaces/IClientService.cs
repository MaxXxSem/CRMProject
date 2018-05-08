using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Infrastructure;

namespace CRMProject.BLL.Interfaces
{
    // clients operations
    public interface IClientService
    {
        // get all clients list
        IEnumerable<ClientDTO> GetClients();

        // add new client
        bool AddClient(ClientDTO client);

        // get client's info
        ClientDTO GetClientData(int id);

        // update client's info
        bool SetClientData(ClientDTO client);

        // delete client
        bool DeleteClient(int id);

        // get transactions related with client
        IEnumerable<TransactionDTO> GetTransactions(int clientId);

        // get contacts related with client
        IEnumerable<ContactDTO> GetContacts(int clientId);

        // send email to client
        bool SendEmail(Email email);
    }
}
