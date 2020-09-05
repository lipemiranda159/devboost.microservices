using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class PedidosController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly IPedidoFacade _pedidoFacade;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public PedidosController(IPedidoRepository pedidoRepository, IPedidoFacade pedidoFacade, IClienteRepository clienteRepository)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _pedidoFacade = pedidoFacade;
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
        }

        [HttpPost("assign-drone")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public async Task<ActionResult> AssignDrone()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            await _pedidoFacade.AssignDrone(_pedidoRepository);
            return Ok();
        }

        [HttpPost]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            var clientePedido = _clienteRepository.GetCliente(pedido.Cliente.Id);

            pedido.Cliente = clientePedido;
            pedido.DataHoraInclusao = DateTime.Now;
            pedido.Situacao = (int)StatusPedido.AGUARDANDO;
            await _pedidoRepository.SavePedidoAsync(pedido);

            return pedido;
        }

    }
}
