using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CRMProject.BLL.Interfaces;
using CRMProject.Models.ViewModels;

namespace CRMProject.Controllers
{
    public class ContactController : Controller
    {
        private IContactService service { get; set; }

        public ContactController(IContactService contactService)
        {
            service = contactService;
        }

        // GET: Contact
        public async Task<ActionResult> ContactsList()
        {
            var contacts = await service.GetContacts();
            List<ContactBasicViewModel> viewContacts = new List<ContactBasicViewModel>();
            if (contacts != null && contacts.Count() > 0)
            {
                foreach (var contact in contacts)
                {
                    viewContacts.Add(new ContactBasicViewModel()
                    {
                        Id = contact.Id,
                        Name = contact.Name,
                        Email = contact.Email,
                        PhoneNumber = contact.PhoneNumber,
                        ClientName = contact.ClientName
                    });
                }
            }

            return View(viewContacts);
        }
    }
}