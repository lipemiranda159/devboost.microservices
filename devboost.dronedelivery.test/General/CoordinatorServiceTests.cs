using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.felipe.Services;
using Xunit;

namespace devboost.dronedelivery.test.General
{
    public class CoordinatorServiceTests
    {
        [Fact]
        public void GetKmDistanceTest()
        {
            var coordinatiorService = new CoordinateService();
            var pedido = SetupTests.GetPedido();
            var distance = coordinatiorService.GetKmDistance(pedido.GetPoint(), new felipe.DTO.Point());
            Assert.True(distance == 489.8);
        }
    }
}
