using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Cliente
{
    public class ClienteTest
    {
        IClienteRepository _repository;

        public ClienteTest()
        {
            _repository = new ClienteRepositoryFake();
        }

        [Fact]
        public void CriarCliente()
        {
            double latitude = 23.5741381;
            double longitude = 46.6610177;
            string nome = "Marco";
            string password = "AdminAPIDrone01!";

            var cliente = new devboost.dronedelivery.felipe.DTO.Models.Cliente()
            {
                Latitude = latitude,
                Longitude = longitude,
                Nome = nome,
                Password = password
            };

            Assert.Equal(latitude, cliente.Latitude);
            Assert.Equal(longitude, cliente.Longitude);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(password, cliente.Password);

        }

        [Fact]
        public void GetCliente()
        {
            var clienteId = 1;

            var cliente = _repository.GetCliente(clienteId);

            Assert.IsType<devboost.dronedelivery.felipe.DTO.Models.Cliente>(cliente);
            Assert.Equal(clienteId, cliente.Id);

        }

        [Fact]
        public void GetClientes()
        {
            var clientes = _repository.GetClientes();

            Assert.IsType<List<devboost.dronedelivery.felipe.DTO.Models.Cliente>>(clientes);
            Assert.Equal(5, clientes.Count());
        }

        [Fact]
        public void Save()
        {

            var cliente = new devboost.dronedelivery.felipe.DTO.Models.Cliente()
            {
                Latitude = 23.5741381,
                Longitude = 46.6610177,
                Nome = "Silvio",
                Password = "AdminAPIDrone06!"
            };

            var result = _repository.SaveCliente(cliente);

            Assert.Equal(Task.CompletedTask, result);

        }

    }
}
