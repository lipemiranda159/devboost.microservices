using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ClienteController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly IClienteRepository _clienteRepository;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ClienteController(IClienteRepository clienteRepository)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [AllowAnonymous]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ActionResult<IEnumerable<Cliente>> Get()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return _clienteRepository.GetClientes().ToList();
        }

        [HttpPost]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public async Task<ActionResult<Cliente>> Post(Cliente cliente)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            await _clienteRepository.SaveCliente(cliente);
            return cliente;
        }

    }
}
