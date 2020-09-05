using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade.Interface;
using devboost.dronedelivery.felipe.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace devboost.dronedelivery.felipe.Facade
{
    public class DroneFacade : IDroneFacade
    {
        private readonly IDroneService _droneService;
        private readonly IDroneRepository _droneRepository;
        public DroneFacade(IDroneService droneService, IDroneRepository droneRepository)
        {
            _droneService = droneService;
            _droneRepository = droneRepository;
        }
        public List<StatusDroneDto> GetDroneStatusAsync()
        {
            return _droneService.GetDroneStatusAsync().ToList();
        }

        public Drone SaveDrone(Drone drone)
        {
            drone.Perfomance = (drone.Autonomia / 60.0f) * drone.Velocidade;

            _droneRepository.SaveDrone(drone);

            return drone;
        }

    }
}
