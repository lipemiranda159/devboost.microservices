using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.Facade.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Controllers
{
    /// <summary>
    /// Pagamento controller
    /// </summary>
    //[Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoFacade _pagamentoFacade;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagamentoFacade"></param>
        public PagamentoController(IPagamentoFacade pagamentoFacade)
        {
            _pagamentoFacade = pagamentoFacade;
        }
        /// <summary>
        /// Controller para recebimento de status de pagamento
        /// </summary>
        /// <param name="listaPagamentos"></param>
        [HttpPost]
        public async Task AtualizaLista(List<PagamentoStatusDto> listaPagamentos)
        {
            await _pagamentoFacade.ProcessaPagamentosAsync(listaPagamentos);
        }
    }
}
