using System;

namespace Caelum.Leilao
{
    public class Palindromo 
    {
        public bool EhPalindromo(String frase) 
        {
            String fraseFiltrada = frase
                .ToUpper().Replace(" ", "").Replace("-", "");

            for(int i = 0; i < (fraseFiltrada.Length); i++) 
            {
                if(fraseFiltrada[i] != fraseFiltrada[fraseFiltrada.Length - i-1]) 
                {
                    return false;
                }
            }

            return true;
        }
    }
}