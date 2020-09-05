using devboost.dronedelivery.felipe.Controllers;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Controller
{
    public class ClientControllerTests
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientControllerTests()
        {
            _clienteRepository = Substitute.For<IClienteRepository>();
        }

        [Fact]
        public void TestGetClientes()
        {
            var clientController = new ClienteController(_clienteRepository);
            _clienteRepository.GetClientes().Returns(SetupTests.GetClientes());
            var clientes = clientController.Get();

            Assert.True(clientes.Value.Count() == 1);

        }
        [Fact]
        public async Task TestPostCliente()
        {
            var clientController = new ClienteController(_clienteRepository);
            var clienteSetup = SetupTests.GetCliente();
            var client = await clientController.Post(clienteSetup);
            Assert.True(client.Value.Equals(clienteSetup));
            await _clienteRepository.Received().SaveCliente(Arg.Any<felipe.DTO.Models.Cliente>());


        }


    }
}
