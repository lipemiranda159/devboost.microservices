using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Services;
using devboost.dronedelivery.felipe.Services.Interfaces;
using Xunit;

namespace devboost.dronedelivery.test.Drone
{
    public class ConsultaStatusDroneUnitTest
    {
        [Fact]
        public void ConsultarStatusDrone()
        {
            ICoordinateService coordinateService = new CoordinateService();
            IPedidoDroneRepository pedidoDroneRepository = null;
            IDroneRepository droneRepository = new MockDroneRepository();

            IPedidoRepository pedidoRepository = null;

            IDroneService droneService = new DroneService(coordinateService, pedidoDroneRepository, droneRepository, pedidoRepository);

            droneService.GetDroneStatusAsync();

            Assert.Equal<int>(2, droneService.GetDroneStatusAsync().Count);
        }

        [Fact]
        public void CriarDroneStatusResult()
        {
            DroneStatusResult droneStatusResult = new DroneStatusResult
            {
                Id = 1,
                Capacidade = 100,
                Velocidade = 45,
                Autonomia = 30,
                Carga = 650,
                Perfomance = 54.7F,
                SomaPeso = 80,
                SomaDistancia = 8
            };

            Assert.True(droneStatusResult.Id == 1);
            Assert.True(droneStatusResult.Capacidade == 100);
            Assert.True(droneStatusResult.Velocidade == 45);
            Assert.True(droneStatusResult.Autonomia == 30);
            Assert.True(droneStatusResult.Carga == 650);
            Assert.True(droneStatusResult.Perfomance == 54.7F);
            Assert.True(droneStatusResult.SomaPeso == 80);
            Assert.True(droneStatusResult.SomaDistancia == 8);

            Assert.NotNull(droneStatusResult);
        }

        [Fact]
        public void CriarStatusDroneDto()
        {
            StatusDroneDto statusDroneDto = new StatusDroneDto
            {
                Situacao = true,
                PedidoId = 5,
                ClienteId = 1,
                Nome = "Cliente Teste",
                Latitude = 765764.98,
                Longitude = 235764.98
            };

            Assert.True(statusDroneDto.Situacao);
            Assert.True(statusDroneDto.PedidoId == 5);
            Assert.True(statusDroneDto.ClienteId == 1);
            Assert.True(statusDroneDto.Nome =="Cliente Teste");
            Assert.True(statusDroneDto.Latitude == 765764.98);
            Assert.True(statusDroneDto.Longitude == 235764.98);


            Assert.NotNull(statusDroneDto);
        }

    }
}
