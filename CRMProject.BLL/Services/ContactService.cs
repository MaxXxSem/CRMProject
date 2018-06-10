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
                var comments = await Db.Comments.Get(c => c.TypeId == contact.TypeId && c.CommentedEntityId == contact.Id);
                Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());

                ContactDTO contactDTO = new ContactDTO()
                {
                    Id = contact.Id,
                    Email = contact.Email,
                    Name = contact.Name,
                    Desctiption = contact.Description,
                    PhoneNumber = contact.PhoneNumber,
                    ClientId = contact.ClientId,
                    TransactionId = contact.TransactionId,
                    Comments = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments)
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
            if (contact != null)
            {
                Contact cont = await Db.Contacts.Find(contact.Id);

                if (cont != null)
                {
                    cont.Name = contact.Name;
                    cont.Email = contact.Email;
                    cont.PhoneNumber = contact.PhoneNumber;
                    cont.Description = contact.Desctiption;

                    await Db.Contacts.Update(cont);
                    Db.Save();
                    return true;
                }
            }

            return false;
        }

        public async Tasks.Task<IEnumerable<ContactDTO>> GetContacts()
        {
            //var contacts = await Db.Contacts.GetAll();
            //Mapper.Initialize(cfg => cfg.CreateMap<Contact, ContactDTO>());
            //var contactsDTO = Mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(contacts);
            var contacts = await Db.Contacts.GetAll();
            List<ContactDTO> contactsDTO = new List<ContactDTO>();
            if (contacts != null && contacts.Count() > 0)
            {
                foreach (var contact in contacts)
                {
                    ContactDTO contactDTO = new ContactDTO()
                    {
                        Id = contact.Id,
                        Name = contact.Name,
                        Email = contact.Email,
                        Desctiption = contact.Description,
                        PhoneNumber = contact.PhoneNumber,
                        ClientId = contact.ClientId,
                        TransactionId = contact.TransactionId
                    };

                    if (contactDTO.ClientId.HasValue)
                    {
                        contactDTO.ClientName = (await Db.Clients.Find(contactDTO.ClientId.Value)).Name;
                    }

                    contactsDTO.Add(contactDTO);
                }
            }

            return contactsDTO;
        }

        // TODO
        public Tasks.Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }

        public async Tasks.Task<bool> AddComment(int contactId, int typeId, string commentText, int userId)
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
                    CommentedEntityId = contactId,
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
