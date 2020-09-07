using System;
using Xunit;
using devboost.dronedelivery.domain.Extensions;

namespace devboost.dronedelivery.test
{
    public class DroneExtensionsTests
    {
        [Fact]
        public void TestToTempoGasto()
        {
            var drone = SetupTests.GetDrone();
            var date = drone.ToTempoGasto(100);
            Assert.True(date.Hour == DateTime.Now.AddHours(2).Hour);
        }
    }
}
