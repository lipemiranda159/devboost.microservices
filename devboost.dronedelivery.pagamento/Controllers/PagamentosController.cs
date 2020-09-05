﻿using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.pagamento.Interfaces;
using devboost.dronedelivery.pagamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PagamentosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPagamentoFacade _pagamentoFacade;

        public PagamentosController(DataContext context, IPagamentoFacade pagamentoFacade)
        {
            _context = context;
            _pagamentoFacade = pagamentoFacade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamento()
        {
            return await _context.Pagamento.ToListAsync();
        }

        [HttpGet]
        [Route("VerificarStatusPagamentos")]
        public async Task<ActionResult<IEnumerable<PagamentoStatusDto>>> VerificarStatusPagamentos()
        {
            try
            {
                var consulta = await _pagamentoFacade.VerificarStatusPagamentos();

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
            var pagamento = await _context.Pagamento.FindAsync(id);

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

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
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
                Pagamento newPagamento = await _pagamentoFacade.CriarPagamento(pagamento);
                return CreatedAtAction("GetPagamento", new { id = newPagamento.Id }, newPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamento.Any(e => e.Id == id);
        }
    }
}
