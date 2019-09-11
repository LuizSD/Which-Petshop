using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WhichPetshop;

namespace WhichPetShopTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Solucao_UmCaoDeCadaDiaDeSemana_PetShopMeuCaninoFeliz()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 1;
            var caesGrandes = 1;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data,caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Feliz"));
        }

        [TestMethod]
        public void Solucao_UmCaoDeCadaFinalDeSemana_PetShopMeuCaninoFeliz()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("14/09/2019");
            var caesPequenhos = 1;
            var caesGrandes = 1;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Feliz"));
        }

        [TestMethod]
        public void Solucao_UmCaoGrandeFinalDeSemana_PetShopChowChawgas()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("14/09/2019");
            var caesPequenhos = 0;
            var caesGrandes = 1;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("ChowChawgas"));
        }

        [TestMethod]
        public void Solucao_UmCaoGrandeDiaDeSemana_PetShopMeuCaninoFeliz()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 0;
            var caesGrandes = 1;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Feliz"));
        }

        [TestMethod]
        public void Solucao_UmCaoPequenoDiaDeSemana_PetShopVaiRex()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 1;
            var caesGrandes = 0;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Rex"));
        }

        [TestMethod]
        public void Solucao_UmCaoPequenoFinalDeSemana_PetShopVaiRex()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("14/09/2019");
            var caesPequenhos = 1;
            var caesGrandes = 0;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Rex"));
        }

        [TestMethod]
        public void Solucao_DoisDeCadaTipooFinalDeSemana_PetShopMeuCaninoFeliz()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("14/09/2019");
            var caesPequenhos = 2;
            var caesGrandes = 2;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Feliz"));
        }

        [TestMethod]
        public void Solucao_DoisDeCadaTipooDiaDeSemana_PetShopMeuCaninoFeliz()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 2;
            var caesGrandes = 2;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Feliz"));
        }

        [TestMethod]
        public void Solucao_UmPequenoDoisGrandeTipooDiaDeSemana_PetShopMeuCaninoFeliz()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 1;
            var caesGrandes = 2;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Feliz"));
        }

        [TestMethod]
        public void Solucao_UmPequenoDoisGrandeTipooFinalDeSemana_PetShopChowChawgas()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("14/09/2019");
            var caesPequenhos = 1;
            var caesGrandes = 2;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("ChowChawgas"));
        }

        [TestMethod]
        public void Solucao_DoisPequenoUmGrandeTipooDiaDeSemana_PetShopRex()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 2;
            var caesGrandes = 1;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Rex"));
        }

        [TestMethod]
        public void Solucao_DoisPequenoUmGrandeTipooFinalDeSemana_PetShopRex()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("14/09/2019");
            var caesPequenhos = 2;
            var caesGrandes = 1;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Rex"));
        }

        [TestMethod]
        public void Solucao_NenhumCaoFinalDeSemana_PetShopRex()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("14/09/2019");
            var caesPequenhos = 0;
            var caesGrandes = 0;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("ChowChawgas"));
        }

        [TestMethod]
        public void Solucao_NenhumCaoDiaDeSemana_PetShopChowChawgas()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 0;
            var caesGrandes = 0;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("ChowChawgas"));
        }

        [TestMethod]
        public void Solucao_NumeroDeCachorrosAltissimos_PetShopChowChawgas()
        {
            //Arrange
            var solucao = new Solucao();
            var data = Convert.ToDateTime("11/09/2019");
            var caesPequenhos = 999999999;
            var caesGrandes = 999999999;

            //Act
            var resultado = solucao.VerificaMelhorCanil(data, caesPequenhos, caesGrandes);

            //Assert
            Assert.IsTrue(resultado.Contains("Feliz"));
        }

    }
}
