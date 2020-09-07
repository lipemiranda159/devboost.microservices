using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace devboost.dronedelivery.test
{
    public static class SetupTests
    {

        public static DroneStatusDto GetDroneStatusDto()
        {
            return new DroneStatusDto()
            {
                Drone = GetDrone(),
                SomaDistancia = 5,
                SomaPeso = 10
            };
        }
        public static PedidoDrone GetPedidoDrone(StatusEnvio statusEnvio)
        {
            return new PedidoDrone()
            {
                DataHoraFinalizacao = new DateTime(2020, 8, 20, 22, 00, 00),
                Distancia = 5,
                StatusEnvio = (int)statusEnvio,
                Pedido = GetPedido(),
                Drone = GetDrone(),
                DroneId = GetDrone().Id,
                PedidoId = GetPedido().Id
            };
        }

        public static List<PedidoDrone> GetPedidoDrones(StatusEnvio statusEnvio)
        {
            return new List<PedidoDrone>()
            {
                GetPedidoDrone(statusEnvio)
            };
        }

        public static felipe.DTO.Models.Pedido GetPedido()
        {
            var dadosPagamento = new DadosPagamento() { Dados = "", Id = 1 };

            var pedido = new felipe.DTO.Models.Pedido()
            {
                Cliente = new felipe.DTO.Models.Cliente()
                {
                    Nome = "Felipe",
                    Id = 1,
                    Latitude = -19.9539424,
                    Longitude = -43.9750544,
                    Password = "",
                    UserId = ""
                },
                ClienteId = 1,
                Peso = 50,
                Situacao = (int)StatusPedido.AGUARDANDO,
                Pagamento = new felipe.DTO.Models.Pagamento()
                {
                    DadosPagamentos = new List<DadosPagamento>(),
                    TipoPagamento = ETipoPagamento.CARTAO
                }

            };

            pedido.Pagamento.DadosPagamentos.Add(dadosPagamento);

            return pedido;

        }
        public static List<felipe.DTO.Models.Pedido> GetPedidosList()
        {
            return new List<felipe.DTO.Models.Pedido>() {
                GetPedido()
            };
        }

        public static LoginDTO GetLogin()
        {
            return new LoginDTO()
            {
                Password = "teste",
                UserId = "teste"

            };
        }

        public static felipe.DTO.Models.Cliente GetCliente()
        {
            return new felipe.DTO.Models.Cliente()
            {
                Nome = "Felipe",
                Id = 1,
                Latitude = -19.9539424,
                Longitude = -43.9750544,
                Password = "",
                UserId = "teste"

            };
        }

        public static List<felipe.DTO.Models.Cliente> GetClientes()
        {
            return new List<felipe.DTO.Models.Cliente>()
            {
                GetCliente()
            };
        }

        public static List<StatusDroneDto> GetDroneStatus()
        {
            List<StatusDroneDto> statusDroneDtos = new List<StatusDroneDto>();

            StatusDroneDto statusDroneDto = new StatusDroneDto
            {
                ClienteId = 1,
                DroneId = 1,
                Latitude = -23.5880684,
                Longitude = -46.6564195,
                Situacao = true,
                PedidoId = 0,
                Nome = string.Empty
            };

            statusDroneDtos.Add(statusDroneDto);

            StatusDroneDto statusDroneDto2 = new StatusDroneDto
            {
                ClienteId = 1,
                DroneId = 1,
                Latitude = -23.5880684,
                Longitude = -46.6564195,
                Situacao = false,
                PedidoId = 1,
                Nome = "João da Silva"
            };

            statusDroneDtos.Add(statusDroneDto2);

            return statusDroneDtos;
        }

        public static List<felipe.DTO.Models.Drone> GetDrones()
        {
            return new List<felipe.DTO.Models.Drone>()
            {
                GetDrone()
            };
        }

        public static StatusDroneDto GetStatusDroneDto()
        {
            return new StatusDroneDto()
            {
                ClienteId = 1,
                DroneId = 1,
                Latitude = 1.0,
                Longitude = 1.0,
                Nome = "Felipe",
                PedidoId = 1,
                Situacao = false
            };
        }

        public static DroneStatusResult GetDroneStatusResult()
        {
            return new DroneStatusResult
            {
                Autonomia = 100,
                Capacidade = 100,
                Carga = 100,
                Id = 1,
                Perfomance = 1000,
                SomaDistancia = 100,
                SomaPeso = 100,
                Velocidade = 100
            };
        }

        public static List<DroneStatusResult> GetDroneStatusResults()
        {
            return new List<DroneStatusResult>() { GetDroneStatusResult() };
        }
        public static List<StatusDroneDto> GetListStatusDroneDto()
        {
            return new List<StatusDroneDto>()
            {
                GetStatusDroneDto()
            };
        }
        public static felipe.DTO.Models.Drone GetDrone()
        {
            return new felipe.DTO.Models.Drone()
            {
                Id = 1,
                Autonomia = 100,
                Capacidade = 100,
                Carga = 100,
                Perfomance = (100 / 60.0f) * 100,
                Velocidade = 100
            };
        }

        public static DroneDto GetDroneDto()
        {
            return new DroneDto(new DroneStatusDto(GetDrone()), 100);
        }

        public static felipe.DTO.Models.Pagamento GetPagamento()
        {
            return new felipe.DTO.Models.Pagamento()
            {
                TipoPagamento = ETipoPagamento.CARTAO,
                Descricao = "Teste descrição",
                DadosPagamentos = new List<DadosPagamento>()
            };
        }

        public static PaymentSettings GetPaymentSettings()
        {

            var paymentSetting = new PaymentSettings();
            paymentSetting.PaymentsSettings = new List<PaymentSetting>();

            paymentSetting.PaymentsSettings.Add(new PaymentSetting()
            {
                TipoPagamento = (int)ETipoPagamento.CARTAO,
                UrlBase  = "http://localhost:5000/api/"
            });

            paymentSetting.PaymentsSettings.Add(new PaymentSetting()
            {
                TipoPagamento = (int)ETipoPagamento.INDEFINIDO,
                UrlBase = "UrlBasePagamentoIndefinido"
            });

            return paymentSetting;
        }

    }
}
