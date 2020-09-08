﻿using devboost.dronedelivery.core.domain;
using devboost.dronedelivery.core.domain.Entities;
using devboost.dronedelivery.pagamento.domain.Interfaces;
using devboost.dronedelivery.pagamento.EF.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PagamentosController : ControllerBase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPagamentoFacade _pagamentoFacade;

        public PagamentosController(IPagamentoRepository pagamentoRepository, IPagamentoFacade pagamentoFacade)
        {
            _pagamentoRepository = pagamentoRepository;
            _pagamentoFacade = pagamentoFacade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamento()
        {
            var pagamentos = await _pagamentoRepository.GetAllAsync();
            return pagamentos.ToList();
        }

        [HttpGet]
        [Route("VerificarStatusPagamentos")]
        public async Task<ActionResult<IEnumerable<PagamentoStatusDto>>> VerificarStatusPagamentos()
        {
            try
            {
                var consulta = await _pagamentoFacade.VerificarStatusPagamentos();

                if (consulta == null)
                    return BadRequest("Não foi possivel comunicar com a API de Delivery!");

                return consulta.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            var pagamento = await _pagamentoRepository.GetByIdAsync(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.Id)
            {
                return BadRequest();
            }

            _pagamentoRepository.SetState(pagamento, EntityState.Modified);

            try
            {
                await _pagamentoRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _pagamentoRepository.PagamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostPagamento(PagamentoCreateDto pagamento)
        {
            try
            {
                var newPagamento = await _pagamentoFacade.CriarPagamento(pagamento);
                return Ok(newPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}