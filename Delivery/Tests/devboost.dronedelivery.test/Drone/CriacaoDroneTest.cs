﻿using devboost.dronedelivery.domain.core.Enums;
using devboost.dronedelivery.domain.core.Models;
using devboost.dronedelivery.domain.Entites;
using devboost.dronedelivery.domain.Interfaces;
using devboost.dronedelivery.felipe.Facade;
using devboost.dronedelivery.felipe.Services;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test
{
    public class CriacaoDroneTest
    {
        [Fact]
        public async Task CriarDrone()
        {
            IDroneService _droneService = null;
            IDroneRepository _droneRepository = new MockDroneRepository();

            var droneFacade = new DroneFacade(_droneService, _droneRepository);


            var drone = new Drone { Autonomia = 120, Velocidade = 80 };
            await droneFacade.SaveDroneAsync(drone);

            Assert.True(drone.Perfomance == 160);
        }

        [Theory]
        [InlineData(50, 30, 10, true, "O drone deveria aceitar esta carga")]
        [InlineData(50, 30, 20, true, "O drone deveria aceitar esta carga")]
        [InlineData(50, 30, 30, false, "O drone NÃO deveria aceitar esta carga")]
        public void ValidarPeso(int capacidadeDrone, int droneSomaPeso, int pedidoPeso, bool resultadoEsperado, string mensagemErro)
        {
            var drone = new Drone { Id = 1, Capacidade = capacidadeDrone, Velocidade = 40, Autonomia = 50, Carga = 80, Perfomance = 33.3F };

            DroneStatusDto dtoDroneStatus = new DroneStatusDto { Drone = drone, SomaDistancia = 50, SomaPeso = droneSomaPeso };

            Pedido pedido = new Pedido { ClienteId = 1, Peso = pedidoPeso };

            Assert.True(resultadoEsperado == DroneService.ValidaPeso(dtoDroneStatus, pedido), mensagemErro);
        }


        [Theory]
        [InlineData(8, 2, 5, 20, true, "O drone deveria aceitar esta distancia")]
        [InlineData(8, 2, 5, 15, true, "O drone deveria aceitar esta distancia")]
        [InlineData(8, 2, 5, 10, false, "O drone NÃO deveria aceitar esta distancia")]
        public void ValidarDistancia(int somaDistancia, double distanciaRetorno, double pedidoDroneDistancia, float performanceDrone, bool resultadoEsperado, string mensagemErro)
        {
            var drone = new Drone { Id = 1, Capacidade = 500, Velocidade = 40, Autonomia = 50, Carga = 80, Perfomance = performanceDrone };

            DroneStatusDto dtoDroneStatus = new DroneStatusDto { Drone = drone, SomaDistancia = somaDistancia, SomaPeso = 300 };

            Assert.True(resultadoEsperado == DroneService.ValidaDistancia(dtoDroneStatus, distanciaRetorno, pedidoDroneDistancia), mensagemErro);
        }

        [Fact]
        public void finalizaPedido()
        {
            PedidoDrone pedidoUm = new PedidoDrone() { Id = 1, StatusEnvio = (int)StatusEnvio.EM_TRANSITO };
            PedidoDrone pedidoDois = new PedidoDrone() { Id = 2, StatusEnvio = (int)StatusEnvio.EM_TRANSITO };

            List<PedidoDrone> listPedidoDrones = new List<PedidoDrone> { pedidoUm, pedidoDois };

            var _pedidoDroneRepository = new Mock<IPedidoDroneRepository>();
            _pedidoDroneRepository.Setup(_ => _.RetornaPedidosParaFecharAsync().Result).Returns(listPedidoDrones);

            ICoordinateService _coordinateService = null;
            IDroneRepository _droneRepository = null;
            IPedidoRepository _pedidoRepository = null;

            var droneService = new DroneService(_coordinateService, _pedidoDroneRepository.Object, _droneRepository, _pedidoRepository);

            droneService.FinalizaPedidosAsync().Wait();

            var existepedidoComStatusDiferenteDeFinalizado = listPedidoDrones.Any(_ => _.StatusEnvio != (int)StatusEnvio.FINALIZADO);

            Assert.True(!existepedidoComStatusDiferenteDeFinalizado);

        }

        [Fact]
        public void RetornarStatusDrone()
        {
            var sddUm = new StatusDroneDto { ClienteId = 1, PedidoId = 1 };
            var sddDois = new StatusDroneDto { ClienteId = 2, PedidoId = 2 };

            var listSdd = new List<StatusDroneDto> { sddUm, sddDois };

            var _droneRepository = new Mock<IDroneRepository>();
            _droneRepository.Setup(_ => _.GetDroneStatusAsync()).Returns(listSdd);

            ICoordinateService _coordinateService = null;
            IPedidoDroneRepository _pedidoDroneRepository = null;
            IPedidoRepository _pedidoRepository = null;

            var droneService = new DroneService(_coordinateService, _pedidoDroneRepository, _droneRepository.Object, _pedidoRepository);

            var result = droneService.GetDroneStatusAsync();

            Assert.True(result.Count() == 2, "A quantidade de registros retornados não esperada");
        }
    }
}