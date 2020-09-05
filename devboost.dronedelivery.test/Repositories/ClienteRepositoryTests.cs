using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using devboost.dronedelivery.test.Setup;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class ClienteRepositoryTests
    {
        private readonly DataContext _context;
        public ClienteRepositoryTests()
        {
            _context = Substitute.For<DataContext>();
            var dbSet = Substitute.For<Microsoft.EntityFrameworkCore.DbSet<felipe.DTO.Models.Cliente>, IQueryable<felipe.DTO.Models.Cliente>>();
            _context.Cliente = dbSet;
        }

        [Fact]
        public async Task TestSaveClient()
        {
            var clienteRepository = new ClienteRepository(_context);
            await clienteRepository.SaveCliente(SetupTests.GetCliente());
            _context.Received().Cliente.Add(Arg.Any<felipe.DTO.Models.Cliente>());
            await _context.Received().SaveChangesAsync();
        }


        [Fact]
        public void GetCliente()
        {

            var cliente = SetupTests.GetCliente();
            var clienteRepository = new ClienteRepository(_context);

            var result = clienteRepository.GetCliente(cliente.Id);

            _context.Received().Find<felipe.DTO.Models.Cliente>(cliente.Id);

        }

        [Fact]
        public void GetClientes()
        {

            var clienteRepository = new ClienteRepository(_context);

            var clientes = clienteRepository.GetClientes();

            _context.Received().Cliente.AsQueryable<felipe.DTO.Models.Cliente>();

        }

    }
}
