using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.test
{
    public class ClienteRepositoryFake : IClienteRepository
    {

        private readonly List<devboost.dronedelivery.felipe.DTO.Models.Cliente> _clientes;

        public ClienteRepositoryFake()
        {
            _clientes = new List<devboost.dronedelivery.felipe.DTO.Models.Cliente>()
            {
                new devboost.dronedelivery.felipe.DTO.Models.Cliente() { Id = 1, Latitude = 23.5741381, Longitude = 46.6617410, Nome = "Marco", Password = "AdminAPIDrone01!" },
                new devboost.dronedelivery.felipe.DTO.Models.Cliente() { Id = 2, Latitude = 23.5746581, Longitude = 46.6618522, Nome = "Felipe", Password = "AdminAPIDrone02!" },
                new devboost.dronedelivery.felipe.DTO.Models.Cliente() { Id = 3, Latitude = 23.5741247, Longitude = 46.6619637, Nome = "Lucas", Password = "AdminAPIDrone03!" },
                new devboost.dronedelivery.felipe.DTO.Models.Cliente() { Id = 4, Latitude = 23.5748520, Longitude = 46.6617894, Nome = "Italo", Password = "AdminAPIDrone04!" },
                new devboost.dronedelivery.felipe.DTO.Models.Cliente() { Id = 5, Latitude = 23.5743698, Longitude = 46.6614561, Nome = "Danilo", Password = "AdminAPIDrone05!" },

            };
        }

        public devboost.dronedelivery.felipe.DTO.Models.Cliente GetCliente(int id)
        {
            return _clientes.Where(_ => _.Id == id).FirstOrDefault();
        }

        public IEnumerable<devboost.dronedelivery.felipe.DTO.Models.Cliente> GetClientes()
        {
            return _clientes;
        }

        public Task SaveCliente(devboost.dronedelivery.felipe.DTO.Models.Cliente cliente)
        {
            cliente.Id = GerarId();
            _clientes.Add(cliente);

            return Task.CompletedTask;
        }

        public int GerarId()
        {
            var id = _clientes.Max(_ => _.Id) + 1;
            return id;
        }

    }
}
