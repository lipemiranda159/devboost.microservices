using Dapper;
using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories
{
    public class PedidoDroneRepository : RepositoryBase, IPedidoDroneRepository
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IDroneRepository _droneRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidoDroneRepository(DataContext context, IPedidoRepository pedidoRepository, IDroneRepository droneRepository, IClienteRepository clienteRepository, IConfiguration configuration) : base(context, configuration)
        {
            _pedidoRepository = pedidoRepository;
            _droneRepository = droneRepository;
            _clienteRepository = clienteRepository;
        }

        public List<PedidoDrone> RetornaPedidosEmAberto()
        {
            List<PedidoDrone> pedidoDrones = new List<PedidoDrone>();

            var busca = _context.PedidoDrones.Where(FiltroPedidosEmAberto()).ToList();

            if (busca.Count > 0)
            {
                foreach (var b in busca)
                {
                    var pedido = _pedidoRepository.GetPedido(b.PedidoId);
                    var cliente = _clienteRepository.GetCliente(pedido.ClienteId);
                    pedido.Cliente = cliente;

                    PedidoDrone pedidoDrone = new PedidoDrone
                    {
                        Id = b.Id,
                        DataHoraFinalizacao = b.DataHoraFinalizacao,
                        DroneId = b.DroneId,
                        PedidoId = b.PedidoId,
                        Distancia = b.Distancia,
                        StatusEnvio = b.StatusEnvio,
                        Pedido = pedido,
                        Drone = _droneRepository.GetDrone(b.DroneId),
                    };

                    pedidoDrones.Add(pedidoDrone);
                }
            }

            return pedidoDrones;
        }

        private static Expression<Func<PedidoDrone, bool>> FiltroPedidosEmAberto()
        {
            return p => p.StatusEnvio == (int)StatusEnvio.AGUARDANDO;
        }

        public async Task UpdatePedidoDrone(DroneStatusDto drone, double distancia)
        {
            using SqlConnection conexao = new SqlConnection(_connectionString);

            var sql = "UPDATE dbo.PedidoDrones" +
                $" SET StatusEnvio ={(int)StatusEnvio.EM_TRANSITO}," +
                $"DataHoraFinalizacao = '{drone.Drone.ToTempoGasto(distancia)}'" +
                $" WHERE DroneId = {drone.Drone.Id}";

            await conexao.ExecuteAsync(sql);
        }

        public List<PedidoDrone> RetornaPedidosParaFecharAsync()
        {
            return _context
                .PedidoDrones
                .Where(p =>
                    p.StatusEnvio == (int)StatusEnvio.EM_TRANSITO &&
                    p.DataHoraFinalizacao <= DateTime.Now)
                .ToList();
        }

        public async Task<int> UpdatePedido(PedidoDrone pedido)
        {
            _context.PedidoDrones.Update(pedido);
            return await _context.SaveChangesAsync();
        }
    }
}
