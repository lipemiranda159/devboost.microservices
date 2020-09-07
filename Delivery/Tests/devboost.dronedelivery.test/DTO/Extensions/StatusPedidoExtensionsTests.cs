using devboost.dronedelivery.domain.core.Enums;
using devboost.dronedelivery.domain.Extensions;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class StatusPedidoExtensionsTests
    {

        [Fact]
        public void isSuccess()
        {

            var pagamento = SetupTests.GetPagamento();
            pagamento.StatusPagamento = EStatusPagamento.APROVADO;

            var status = pagamento.StatusPagamento.IsSuccess();

            Assert.True(status);

        }

        [Fact]
        public void EmAnalise()
        {
            var pagamento = SetupTests.GetPagamento();
            pagamento.StatusPagamento = EStatusPagamento.EM_ANALISE;

            var status = pagamento.StatusPagamento.EmAnalise();

            Assert.True(status);
        }

    }
}
