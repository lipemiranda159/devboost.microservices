﻿using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class DroneRepositoryTests
    {
        private readonly DataContext _context;
        private readonly DroneRepository _droneRepository;
        private readonly ICommandExecutor<DroneStatusResult> _droneStatusExecutor;
        private readonly ICommandExecutor<StatusDroneDto> _statusDroneExecutor;

        public DroneRepositoryTests()
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
            _context.Received().Find<Drone>(Arg.Any<int>());

        }

        [Fact]
        public void RetornaDroneTests()
        {
            var droneTest = SetupTests.GetDrone();
            var context = ContextProvider<Drone>.GetContext(SetupTests.GetDrones());
            var droneRepository = new DroneRepository(context, _statusDroneExecutor, _droneStatusExecutor);
            var drone = droneRepository.RetornaDrone();
            Assert.True(drone.Equals(droneTest));
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
        public async Task SaveDrone()
        {
            await _droneRepository.SaveDroneAsync(SetupTests.GetDrone());
            _context.Received().Drone.Add(Arg.Any<Drone>());
            await _context.Received().SaveChangesAsync();

        }

        [Fact]
        public void RetornaDroneStatusTests()
        {
            _droneStatusExecutor.ExcecuteCommand(Arg.Any<string>()).Returns(SetupTests.GetDroneStatusResults());
            var droneStatus = _droneRepository.RetornaDroneStatus(1);
            Assert.True(droneStatus != null);
        }
    }
}
