using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using NSubstitute;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class DroneRepoTests
    {
        private readonly DataContext _context;
        private readonly DroneRepository _droneRepository;
        private readonly ICommandExecutor<DroneStatusResult> _droneStatusExecutor;
        private readonly ICommandExecutor<StatusDroneDto> _statusDroneExecutor;

        public DroneRepoTests()
        {
            _context = Substitute.For<DataContext>();
            _droneStatusExecutor = Substitute.For<ICommandExecutor<DroneStatusResult>>();
            _statusDroneExecutor = Substitute.For<ICommandExecutor<StatusDroneDto>>();
            _droneRepository = new DroneRepository(_context, _statusDroneExecutor, _droneStatusExecutor);
        }

        [Fact]
        public void GetDroneTests()
        {
            _droneRepository.GetDrone(1);
            _context.Received().Find<felipe.DTO.Models.Drone>(Arg.Any<int>());

        }
        [Fact]
        public void GetDroneStatusTest()
        {
            _statusDroneExecutor.ExcecuteCommand(Arg.Any<string>())
                .Returns(SetupTests.GetListStatusDroneDto());
            _droneRepository.GetDroneStatusAsync();
            _statusDroneExecutor.Received().ExcecuteCommand(Arg.Any<string>());
        }

        [Fact]
        public void SaveDrone()
        {
            _droneRepository.SaveDrone(SetupTests.GetDrone());
            _context.Received().Drone.Add(Arg.Any<felipe.DTO.Models.Drone>());
            _context.Received().SaveChangesAsync();

        }
    }
}
