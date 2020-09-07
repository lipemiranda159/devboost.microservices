using devboost.dronedelivery.domain.core;
using devboost.dronedelivery.domain.Interfaces;
using Geolocation;

namespace devboost.dronedelivery.Services
{
    public class CoordinateService : ICoordinateService
    {
        public double GetKmDistance(Point originPoint, Point destPoint)
        {
            return GeoCalculator.GetDistance(
                originPoint.Latitude,
                originPoint.Longitude,
                destPoint.Latitude,
                destPoint.Longitude,
                1,
                DistanceUnit.Kilometers);
        }
    }
}
