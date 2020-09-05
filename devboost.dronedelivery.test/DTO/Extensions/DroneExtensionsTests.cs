using devboost.dronedelivery.felipe.DTO.Extensions;
using System;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
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
