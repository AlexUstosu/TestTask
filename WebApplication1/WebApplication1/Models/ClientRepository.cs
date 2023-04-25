using System;
using System.Collections.Generic;
using System.Collections.Concurrent;    //коллекции в многопоточных приложениях
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace WebApplication1.Models
{
    public class ClientRepository : IClientsRepository
    {
        private static ConcurrentDictionary<long, Client> _clients =
            new ConcurrentDictionary<long, Client>();

        public ClientRepository()
        {
            Create(new Client
            {
                Name = "Иван",
                Familia = "Иванов",
                BDay = new DateOnly(2000, 2, 10),
                Email = "abc@mail.ru",
                PhoneNumber = "+79998887766",
                Address = "г.Волгоград,  просп.им. Ленина, д.1"
            });
        }

        public void Create(Client client)
        {
            client.ID = Int64.Parse(Guid.NewGuid().ToString());
            _clients[client.ID] = client;
        }
        public Client Remove(long id)
        {
            Client client;
            _clients.TryRemove(id, out client);
            return client;
        }
        public void Update(Client client)
        {
            _clients[client.ID] = client;
        }
        public Client Get(long id)
        {
            Client client;
            _clients.TryGetValue(id, out client);
            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            return _clients.Values;
        }

    }
}
