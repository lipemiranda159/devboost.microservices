using devboost.dronedelivery.domain.core.Models;
using devboost.dronedelivery.domain.Interfaces;
using devboost.dronedelivery.felipe.Facade;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace devboost.dronedelivery.test.BDD
{
    [Binding]
    public sealed class AdicionarDroneSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IDroneRepository _droneRepository;
        private readonly IDroneService _droneService;
        private readonly IDroneFacade _droneFacade;


        public AdicionarDroneSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _droneRepository = new MockDroneRepository();
            _droneService = null;
            _droneFacade = new DroneFacade(_droneService, _droneRepository);
        }

        [Given("A Autonomia e (.*)")]
        public void GivenTheFirstNumberIs(int autonomia)
        {
            _scenarioContext.Add("autonomia", autonomia);
        }

        [Given("A velocidade e (.*)")]
        public void GivenTheSecondNumberIs(int velocidade)
        {
            _scenarioContext.Add("velocidade", velocidade);
        }

        [When("Quando criamos o Drone")]
        public async Task CriamosDrone()
        {
            var drone = new Drone()
            {
                Autonomia = _scenarioContext.Get<int>("autonomia"),
                Velocidade = _scenarioContext.Get<int>("velocidade")
            };
            await _droneFacade.SaveDroneAsync(drone);

            _scenarioContext.Add("drone", drone);
        }

        [Then("A performance deste Drone deve ser (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            var droneResult = _scenarioContext.Get<Drone>("drone");

            Assert.True(droneResult.Perfomance == 160F);
        }
    }
}
