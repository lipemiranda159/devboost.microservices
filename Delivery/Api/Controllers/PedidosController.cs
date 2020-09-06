using devboost.dronedelivery.felipe.Facade.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Api.Controllers
{
    //[Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class PedidosController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly IPedidoFacade _pedidoFacade;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public PedidosController(IPedidoFacade pedidoFacade)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _pedidoFacade = pedidoFacade;
        }

        [HttpPost("assign-drone")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public async Task<ActionResult> AssignDrone()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            await _pedidoFacade.AssignDroneAsync();
            return Ok();
        }

        [HttpPost]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return await _pedidoFacade.CreatePedidoAsync(pedido);
        }

    }
}
