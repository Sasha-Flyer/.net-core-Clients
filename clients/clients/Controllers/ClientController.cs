using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        public Client Post(Client client) // Сделайте так, чтобы можно было создавать через API клиента (ФИО, Дата рождениями, Дата регистрации)
        {
            ApplicationContext context = new ApplicationContext();
            client.RegistryDate = DateTime.Now;
            context.Add(client);
            context.SaveChanges();
            return client;
        }

        [HttpGet]
        public List<Client> Get() // получение списка клиентов.
        {
            ApplicationContext context = new ApplicationContext();
            return context.Clients.ToList();
        }
        [Route("{id:int:min(1)}")] // получение клиента по идентификатору
        [HttpGet]
        public Client GetId(int id)
        {
            ApplicationContext context = new ApplicationContext();

            return context.Clients.Single<Client>(client => client.Id == id);
        }

    }
}
