using devboost.dronedelivery.felipe.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade.Interface
{
    public interface IPagamentoFacade
    {
        Task ProcessaPagamentosAsync(List<PagamentoStatusDto> pagamentoStatus);
        
    }
}
