using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CRMProject.BLL.DTO;
using CRMProject.BLL.Interfaces;
using CRMProject.Models.ViewModels;

namespace CRMProject.Controllers
{
    public class ClientController : Controller
    {
        private IClientService service { get; set; }

        public ClientController(IClientService clientService)
        {
            service = clientService;
        }

        // GET: Client
        public async Task<ActionResult> ClientsList()
        {
            var clients = await service.GetClients();
            List<ClientBasicViewModel> viewClients = new List<ClientBasicViewModel>();
            if (clients != null && clients.Count() > 0)
            {
                foreach (var client in clients)
                {
                    viewClients.Add(new ClientBasicViewModel()
                    {
                        Id = client.Id,
                        Email = client.Email,
                        Name = client.Name,
                        PhoneNumber = client.PhoneNumber,
                        Site = client.Site
                    });
                }
            }

            return View(viewClients);
        }

        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(AddClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClientDTO client = new ClientDTO()
                {
                    Name = model.Name,
                    Site = model.Site,
                    Address = model.Address,
                    Description = model.Description,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                bool result = await service.AddClient(client);
                if (result)
                {
                    return RedirectToAction("ClientsList");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}