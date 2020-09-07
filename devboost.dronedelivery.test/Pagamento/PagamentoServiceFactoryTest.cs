using Castle.DynamicProxy.Internal;
using devboost.dronedelivery.felipe.Facade.Factory;
using devboost.dronedelivery.felipe.Services.Interfaces;
using NSubstitute;
using Xunit;

namespace devboost.dronedelivery.test.Pagamento
{
    public class PagamentoServiceFactoryTest
    {

        [Fact]
        public void GetPagamentoServicoTest()
        {
            var client = Substitute.For<IHttpHandler>();
            var pagamentoServiceFactory = new PagamentoServiceFactory(SetupTests.GetPaymentSettings(), client);

            var service = pagamentoServiceFactory.GetPagamentoServico(felipe.DTO.Enums.ETipoPagamento.CARTAO);

            Assert.NotNull(service);
            Assert.IsAssignableFrom<IPagamentoServico>(service);

        }

    }
}
