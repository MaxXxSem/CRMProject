using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Infrastructure;

namespace CRMProject.BLL.Interfaces
{
    // contact operations
    public interface IContactService
    {
        // add new contact
        Task<bool> AddContact(ContactDTO contact);

        // delete contact
        Task<bool> DeleteContact(int id);

        // get contact's info
        Task<ContactDTO> GetContactData(int id);

        // update contact's info
        Task<bool> SetContactData(ContactDTO contact);

        // get all contacts list
        Task<IEnumerable<ContactDTO>> GetContacts();

        // send email to contact
        Task<bool> SendEmail(Email email);

        // add comment
        Task<bool> AddComment(int contactId, int typeId, string commentText, int userId);
    }
}
