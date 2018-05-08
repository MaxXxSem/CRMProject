using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Infrastructure;

namespace CRMProject.BLL.Interfaces
{
    // contact operations
    public interface IContactService
    {
        // add new contact
        bool AddContact(ContactDTO contact);

        // delete contact
        bool DeleteContact(int id);

        // get contact's info
        ContactDTO GetContactData(int id);

        // update contact's info
        bool SetContactData(ContactDTO contact);

        // get all contacts list
        IEnumerable<ContactDTO> GetContacts();

        // send email to contact
        bool SendEmail(Email email);
    }
}
