using System;
using System.Runtime.Remoting.Messaging;

namespace Caelum.Leilao
{
    public class CriadorDeLeilao
    {
        private Leilao leilao;
        public CriadorDeLeilao Para(String descricao)
        {
            this.leilao = new Leilao(descricao);
            return this;
        }

        public CriadorDeLeilao Lance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return leilao;
        }
    }
}