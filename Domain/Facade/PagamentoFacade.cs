﻿using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade
{
    public class PagamentoFacade : IPagamentoFacade
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PagamentoFacade(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task ProcessaPagamentosAsync(List<PagamentoStatusDto> pagamentoStatus)
        {
            foreach (var item in pagamentoStatus)
            {
                var pedido = await _pedidoRepository.PegaPedidoPendenteAsync(item.IdPagamento.ToString());
                if (item.Status.IsSuccess())
                {
                    pedido.Situacao = (int)StatusPedido.AGUARDANDO;
                    await _pedidoRepository.SavePedidoAsync(pedido);
                }
            }
        }
    }
}