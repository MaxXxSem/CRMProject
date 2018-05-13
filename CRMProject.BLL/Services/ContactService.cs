using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.BLL.Interfaces;
using CRMProject.DAL.Interfaces;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Infrastructure;
using CRMProject.DAL.Entities;
using AutoMapper;

namespace CRMProject.BLL.Services
{
    public class ContactService : IContactService
    {
        IUnitOfWork Db { get; set; }

        public ContactService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Tasks.Task<bool> AddContact(ContactDTO contact)
        {
            if (contact == null)
            {
                return false;
            }
            else
            {
                Contact contactEntity = new Contact()
                {
                    Name = contact.Name,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Description = contact.Desctiption,
                    ClientId = contact.ClientId,
                    TransactionId = contact.TransactionId
                };
                await Db.Contacts.Create(contactEntity);
                Db.Save();
                return true;
            }
        }

        public async Tasks.Task<bool> DeleteContact(int id)
        {
            var contact = await Db.Contacts.Find(id);
            if (contact != null)
            {
                await Db.Contacts.Delete(contact);
                Db.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Tasks.Task<ContactDTO> GetContactData(int id)
        {
            var contact = await Db.Contacts.Find(id);
            if (contact != null)
            {
                ContactDTO contactDTO = new ContactDTO()
                {
                    Id = contact.Id,
                    Email = contact.Email,
                    Name = contact.Name,
                    Desctiption = contact.Description,
                    PhoneNumber = contact.PhoneNumber,
                    ClientId = contact.ClientId,
                    TransactionId = contact.TransactionId
                };
                return contactDTO;
            }
            else
            {
                return null;
            }
        }

        public async Tasks.Task<bool> SetContactData(ContactDTO contact)
        {
            if (contact == null)
            {
                return false;
            }
            else
            {
                Contact cont = await Db.Contacts.Find(contact.Id);

                cont.Name = contact.Name ?? cont.Name;
                cont.Email = contact.Email ?? cont.Email;
                cont.PhoneNumber = contact.PhoneNumber ?? cont.PhoneNumber;
                cont.Description = contact.Desctiption ?? cont.Description;

                if (contact.ClientId.HasValue)
                {
                    cont.Client = await Db.Clients.Find(contact.ClientId.Value);
                }

                if (contact.TransactionId.HasValue)
                {
                    cont.Transaction = await Db.Transactions.Find(contact.TransactionId.Value);
                }

                await Db.Contacts.Update(cont);
                Db.Save();
                return true;
            }
        }

        public async Tasks.Task<IEnumerable<ContactDTO>> GetContacts()
        {
            var contacts = await Db.Contacts.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Contact, ContactDTO>());
            var contactsDTO = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(contacts);
            return contactsDTO;
        }

        // TODO
        public Tasks.Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
