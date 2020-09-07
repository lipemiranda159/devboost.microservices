using devboost.dronedelivery.domain.core;
using devboost.dronedelivery.domain.core.Entites;
using devboost.dronedelivery.domain.core.Models;
using devboost.dronedelivery.domain.Interfaces.Repositories;
using devboost.dronedelivery.felipe.EF.Repositories;
using System;
using System.Collections.Generic;

namespace devboost.dronedelivery.test
{
    public class MockDroneRepository : RepositoryBase<Drone>, IDroneRepository
    {

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

        public Drone RetornaDrone()
        {
            throw new NotImplementedException();
        }

        public DroneStatusDto RetornaDroneStatus(int droneId)
        {
            throw new NotImplementedException();
        }
    }
}
