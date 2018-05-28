using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class PalindromoTest
    {
        [Test]
        public void PalindromoDeveFuncionar()
        {
            Palindromo palindromo = new Palindromo();
            string fraseCerta = "Anotaram a data da maratona";
            string fraseErrada = "Bla Bla Bla";


            Assert.AreEqual(true, palindromo.EhPalindromo(fraseCerta));
            Assert.AreEqual(false, palindromo.EhPalindromo(fraseErrada));
        }
        
    }
}