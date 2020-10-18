using BaseJuros.Servicos;
using System;
using Xunit;

namespace BaseJuros.Testes
{
    public class BaseJurosServicoTeste
    {
        //Classe_Metodo_comportamentoEsperado
        [Fact]
        public void BaseJurosServico_RetornaBaseJuros_RetornaValorDoJurosBase()
        {
            // Arrange
            var juro = new Servicos.BaseJurosServico();

            // Act
            var resultado = juro.RetornaBaseJuros();

            //Assert
            Assert.Equal(0.01, resultado);
        }
    }
}
