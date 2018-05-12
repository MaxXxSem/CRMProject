using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.BLL.Interfaces;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Infrastructure;
using CRMProject.DAL.Interfaces;
using CRMProject.DAL.Entities;

namespace CRMProject.BLL.Services
{
    class ClientService : IClientService
    {
        IUnitOfWork Db { get; set; }

        public ClientService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Tasks.Task<bool> AddClient(ClientDTO client)
        {
            try
            {
                Client cl = new Client()
                {
                    Email = client.Email,
                    Name = client.Name,
                    PhoneNumber = client.PhoneNumber,
                    Address = client.Address,
                    Description = client.Description,
                    Site = client.Site
                };

                await Db.Clients.Create(cl);
                Db.Save();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Tasks.Task<bool> DeleteClient(int id)
        {
            try
            {
                Client client = await Db.Clients.Find(id);
                if (client != null)
                {
                    await Db.Clients.Delete(client);
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Tasks.Task<ClientDTO> GetClientData(int id)
        {
            try
            {
                var client = await Db.Clients.Find(id);
                if (client != null)
                {
                    ClientDTO clientData = new ClientDTO()
                    {
                        Id = client.Id,
                        Email = client.Email,
                        Name = client.Name,
                        Address = client.Address,
                        Description = client.Description,
                        PhoneNumber = client.PhoneNumber,
                        Site = client.Site
                    };

                    return clientData;
                }

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Tasks.Task<IEnumerable<ClientDTO>> GetClients()
        {
            throw new NotImplementedException();
        }

        public Tasks.Task<IEnumerable<ContactDTO>> GetContacts(int clientId)
        {
            throw new NotImplementedException();
        }

        public Tasks.Task<IEnumerable<TransactionDTO>> GetTransactions(int clientId)
        {
            throw new NotImplementedException();
        }

        public Tasks.Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }

        public Tasks.Task<bool> SetClientData(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
