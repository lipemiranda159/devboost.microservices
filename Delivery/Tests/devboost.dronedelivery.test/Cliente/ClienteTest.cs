using devboost.dronedelivery.domain.core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test
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
            const double latitude = 23.5741381;
            const double longitude = 46.6610177;
            const string nome = "Marco";
            const string password = "AdminAPIDrone01!";

            var cliente = new Cliente()
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
        public async Task GetCliente()
        {
            const int clienteId = 1;

            var cliente = await _repository.GetByIdAsync(clienteId);

            Assert.IsType<Cliente>(cliente);
            Assert.Equal(clienteId, cliente.Id);

        }

        [Fact]
        public void GetClientes()
        {
            var clientes = _repository.GetClientes();

            Assert.IsType<List<Cliente>>(clientes);
            Assert.Equal(5, clientes.Count());
        }

        [Fact]
        public void Save()
        {

            var cliente = new Cliente()
            {
                Latitude = 23.5741381,
                Longitude = 46.6610177,
                Nome = "Silvio",
                Password = "AdminAPIDrone06!"
            };

            var result = _repository.UpdateAsync(cliente);

            Assert.Equal(Task.CompletedTask, result);

        }

    }
}
