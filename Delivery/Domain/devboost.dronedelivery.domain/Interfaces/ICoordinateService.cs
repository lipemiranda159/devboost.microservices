using devboost.dronedelivery.domain.core;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface ICoordinateService
    {
        double GetKmDistance(Point originPoint, Point destPoint);
    }
}
