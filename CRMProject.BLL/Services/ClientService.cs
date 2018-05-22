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
using AutoMapper;

namespace CRMProject.BLL.Services
{
    public class ClientService : IClientService
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
                    Db.Save();
                    return true;
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

        // TODO: Comments
        public async Tasks.Task<ClientDTO> GetClientData(int id)
        {
            try
            {
                var client = await Db.Clients.Find(id);
                if (client != null)
                {
                    var comments = await Db.Comments.Get(c => c.TypeId == client.TypeId && c.CommentedEntityId == client.Id);
                    Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());

                    ClientDTO clientData = new ClientDTO()
                    {
                        Id = client.Id,
                        Email = client.Email,
                        Name = client.Name,
                        Address = client.Address,
                        Description = client.Description,
                        PhoneNumber = client.PhoneNumber,
                        Site = client.Site,
                        Comments = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments)
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

        public async Tasks.Task<IEnumerable<ClientDTO>> GetClients()
        {
            IEnumerable<Client> clients = await Db.Clients.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientDTO>());
            var clientsDTO = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(clients);
            return clientsDTO;
        }

        public async Tasks.Task<IEnumerable<ContactDTO>> GetContacts(int clientId)
        {
            var contacts = await Db.Contacts.Get(c => c.Client.Id == clientId);
            Mapper.Initialize(cfg => cfg.CreateMap<Contact, ContactDTO>());
            var contactsDTO = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(contacts);
            return contactsDTO;

        }

        public async Tasks.Task<IEnumerable<TransactionDTO>> GetTransactions(int clientId)
        {
            var transactions = await Db.Transactions.Get(t => t.Client.Id == clientId);
            Mapper.Initialize(cfg => cfg.CreateMap<Transaction, TransactionDTO>());
            var transactionsDTO = Mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDTO>>(transactions);
            return transactionsDTO;
        }

        // TODO
        public Tasks.Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }

        public async Tasks.Task<bool> SetClientData(ClientDTO client)
        {
            if (client != null)
            {
                var clientEntity = await Db.Clients.Find(client.Id);

                if (clientEntity != null)
                {
                    clientEntity.Name = client.Name;
                    clientEntity.Email = client.Email;
                    clientEntity.PhoneNumber = client.PhoneNumber;
                    clientEntity.Address = client.Address;
                    clientEntity.Site = client.Site;
                    clientEntity.Description = client.Description;
                    await Db.Clients.Update(clientEntity);
                    Db.Save();
                    return true;
                }
            }

            return false;
        }

        public async Tasks.Task<bool> AddComment(int clientId, int typeId, string commentText, int userId)
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
                    CommentedEntityId = clientId,
                    TypeId = typeId,
                    User = await Db.Users.Find(userId)
                };

                await Db.Comments.Create(comment);
                Db.Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
