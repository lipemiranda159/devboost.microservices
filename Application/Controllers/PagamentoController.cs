using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.Facade.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace devboost.dronedelivery.felipe.Controllers
{
    /// <summary>
    /// Pagamento controller
    /// </summary>
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
