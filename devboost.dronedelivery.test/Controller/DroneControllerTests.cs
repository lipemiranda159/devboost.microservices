using devboost.dronedelivery.felipe.Controllers;
using devboost.dronedelivery.felipe.Facade.Interface;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Controller
{
    public class DroneControllerTests
    {
        private readonly IDroneFacade _droneFacade;

        public DroneControllerTests()
        {
            _droneFacade = Substitute.For<IDroneFacade>();
        }

        [Fact]
        public void TestGetStatusDrone()
        {
            _droneFacade.GetDroneStatusAsync().Returns(SetupTests.GetDroneStatus());
            var droneController = new DronesController(_droneFacade);
            droneController.GetStatusDrone();
            _droneFacade.Received().GetDroneStatusAsync();

        }

        [Fact]
        public async Task PostDrone()
        {
            var droneController = new DronesController(_droneFacade);
            await droneController.PostDrone(SetupTests.GetDrone());
            _droneFacade.Received().SaveDrone(Arg.Any<felipe.DTO.Models.Drone>());
        }
    }
}
