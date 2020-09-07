using devboost.dronedelivery.domain.core.Entities;

namespace devboost.dronedelivery.domain.core
{
    public sealed class DroneStatusDto
    {
        public DroneStatusDto()
        {

        }

        public DroneStatusDto(Drone d)
        {
            Drone = d;
        }

        public Drone Drone { get; set; }

        public int SomaPeso { get; set; }
        public int SomaDistancia { get; set; }
    }
}
