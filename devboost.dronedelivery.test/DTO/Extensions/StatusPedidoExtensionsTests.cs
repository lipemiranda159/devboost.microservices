using devboost.dronedelivery.felipe.DTO.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class StatusPedidoExtensionsTests
    {

        [Fact]
        public void isSuccess()
        {

            var pagamento = SetupTests.GetPagamento();
            pagamento.StatusPagamento = felipe.DTO.Enums.EStatusPagamento.APROVADO;

            var status = pagamento.StatusPagamento.IsSuccess();

            Assert.True(status);

        }

        [Fact]
        public void EmAnalise()
        {
            var pagamento = SetupTests.GetPagamento();
            pagamento.StatusPagamento = felipe.DTO.Enums.EStatusPagamento.EM_ANALISE;

            var status = pagamento.StatusPagamento.EmAnalise();

            Assert.True(status);
        }

    }
}
