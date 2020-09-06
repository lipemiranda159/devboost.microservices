using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.test.Drone
{
    public class MockDroneRepository : IDroneRepository
    {
        public felipe.DTO.Models.Drone GetDrone(int id)
        {
            throw new NotImplementedException();
        }

        public List<StatusDroneDto> GetDroneStatusAsync()
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

            var statusDroneDto2 = new StatusDroneDto
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

        public felipe.DTO.Models.Drone RetornaDrone()
        {
            throw new NotImplementedException();
        }

        public DroneStatusDto RetornaDroneStatus(int droneId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveDroneAsync(felipe.DTO.Models.Drone drone)
        {

        }
    }
}
