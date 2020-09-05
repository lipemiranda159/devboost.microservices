using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade.Factory;
using devboost.dronedelivery.felipe.Facade.Interface;
using devboost.dronedelivery.felipe.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade
{
    public class PedidoFacade : IPedidoFacade
    {
        private readonly DataContext _dataContext;
        private readonly IPedidoService _pedidoService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IDroneRepository _droneRepository;
        private readonly IPagamentoServiceFactory _pagamentoServiceFactory;
        public PedidoFacade(
            DataContext dataContext,
            IPedidoService pedidoFacade,
            IClienteRepository clienteRepository,
            IPedidoRepository pedidoRepository,
            IDroneRepository droneRepository,
            IPagamentoServiceFactory pagamentoServiceFactory)
        {
            _dataContext = dataContext;
            _pedidoService = pedidoFacade;
            _clienteRepository = clienteRepository;
            _pedidoRepository = pedidoRepository;
            _droneRepository = droneRepository;
            _pagamentoServiceFactory = pagamentoServiceFactory;
        }
        public async Task AssignDroneAsync()
        {
            var pedidos = _pedidoRepository.ObterPedidos((int)StatusPedido.AGUARDANDO);
            if (pedidos?.Count > 0)
            {
                foreach (var pedido in pedidos)
                {
                    var cliente = _clienteRepository.GetCliente(pedido.ClienteId);
                    pedido.Cliente = cliente;
                    var drone = await _pedidoService.DroneAtendePedido(pedido);
                    if (drone != null)
                    {
                        await AtualizaPedidoAsync(pedido);
                        await AdicionarPedidoDrone(pedido, drone);
                    }
                }
            }
        }

        private async Task AdicionarPedidoDrone(Pedido pedido, DTO.DroneDto drone)
        {
            var newDrone = _droneRepository.GetDrone(drone.DroneStatus.Drone.Id);
            var newPedido = _pedidoRepository.GetPedido(pedido.Id);

            var pedidoDrone = new PedidoDrone()
            {
                Distancia = drone.Distancia,
                Drone = newDrone,
                DroneId = drone.DroneStatus.Drone.Id,
                Pedido = newPedido,
                PedidoId = pedido.Id,
                StatusEnvio = (int)StatusEnvio.AGUARDANDO
            };

            _dataContext.PedidoDrones.Add(pedidoDrone);
            await _dataContext.SaveChangesAsync();
        }

        private async Task AtualizaPedidoAsync(Pedido pedido)
        {
            pedido.Situacao = (int)StatusPedido.AGUARDANDO_ENVIO;
            pedido.DataUltimaAlteracao = DateTime.Now;
            _dataContext.Pedido.Update(pedido);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
        {
            if (pedido.EValido())
            {
                var clientePedido = _clienteRepository.GetCliente(pedido.ClienteId);
                pedido.Cliente = clientePedido;
                pedido.DataHoraInclusao = DateTime.Now;
                pedido.Situacao = (int)StatusPedido.AGUARDANDO_PAGAMENTO;
                var servicoPagamento = _pagamentoServiceFactory.GetPagamentoServico(pedido.Pagamento.TipoPagamento);
                var responseGateway = await servicoPagamento.RequisitaPagamento(pedido.Pagamento);
                pedido.GatewayPagamentoId = responseGateway.Id.ToString();

                await _pedidoRepository.SavePedidoAsync(pedido);
                return pedido;
            }
            else throw new Exception("Pedido inválido");
        }
    }
}
