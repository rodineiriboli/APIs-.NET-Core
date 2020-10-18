using Calculo.Servicos;
using System;
using Xunit;

namespace Calculo.Testes
{
    public class CalculoServicoTeste
    {
        [Fact]
        public void CalculoServico_CalculaJuros_RetornaValorDoCalculo()
        {
            // Arrange
            var calculaJuros = new CalculoServicos();

            // Act
            var resultado = calculaJuros.CalculaJuros(100, 0.01, 5);

            // Assert
            Assert.Equal(Convert.ToDecimal(105.10), resultado);
        }
    }
}
