using System;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;
        
        [SetUp]
        public void criaAvaliador()
        {
            this.leiloeiro = new Avaliador();
            
            this.joao = new Usuario("João");
            this.jose = new Usuario("Jose");
            this.maria = new Usuario("Maria");
        }
        
        [Test]
        public void DeveEntenderLancesEmOrdensCrescente()
        {
            // 1a parte: cenario
            Leilao leilao = new Leilao("Playstation 3 Novo");
            
            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));
            
            //2a parte: acao
            leiloeiro.Avalia(leilao);

            //3a parte: validacao
            double maiorEsperado = 400;
            double menorEsperado = 250;
            double mediaEsperada = (250.0 + 300.0 + 400.0) / 3;
            
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
            Assert.AreEqual(mediaEsperada, leiloeiro.ValorMedio);
        }

        [Test]
        public void DeveEntenderLeilaoComAPenasUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(joao, 1000)
                .Constroi();
            
            leilao.Propoe(new Lance(joao, 1000.0));
            
            leiloeiro.Avalia(leilao);
            
            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Lance(joao, 100)
                .Lance(maria, 200)
                .Lance(joao, 300)
                .Lance(maria, 400)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);

        }
        [Test]
        public void FuncionaCasoOLeilaoPossuaApenasUmLance()
        {
            Usuario fulano = new Usuario("Fulano");
            Leilao leilao = new Leilao("Playstation 4 Velho");
            
            leilao.Propoe(new Lance(fulano, 200.0));
            
            leiloeiro.Avalia(leilao);

            var menores = leiloeiro.MenorLance;
            var maiores = leiloeiro.MaiorLance;
            
            Assert.AreEqual(200, menores);
            Assert.AreEqual(200, maiores);

        }

        [Test]
        public void NaoDeveAvaliarLeiloesSemNenhumLanceDado()
        {
                Leilao leilao = new CriadorDeLeilao().Para("Playstation").Constroi();


            Assert.That(() => leiloeiro.Avalia(leilao), 
                Throws.TypeOf<Exception>());
        }
    }
}