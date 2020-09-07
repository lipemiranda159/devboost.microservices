using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.felipe.EF.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class ClienteRepositoryTests
    {

        [Fact]
        public async Task TestSaveClient()
        {
            var context = ContextProvider<Cliente>.GetContext(null);
            var clienteRepository = new ClienteRepository(context);
            await clienteRepository.AddAsync(SetupTests.GetCliente(1));
            await context.SaveChangesAsync();
        }


        [Fact]
        public async Task GetCliente()
        {

            var cliente = SetupTests.GetCliente(2);
            var context = ContextProvider<Cliente>.GetContext(null);
            var clienteRepository = new ClienteRepository(context);
            await clienteRepository.AddAsync(cliente);
            var result = await clienteRepository.GetByIdAsync(cliente.Id);

            Assert.True(cliente.Equals(result));

        }

        [Fact]
        public async Task GetClientes()
        {

            var context = ContextProvider<Cliente>.GetContext(null);
            var clienteRepository = new ClienteRepository(context);
            var cliente = SetupTests.GetCliente(3);
            await clienteRepository.AddAsync(cliente);

            var clientes = await clienteRepository.GetAllAsync();

            Assert.True(clientes.Any());

        }

    }
}
