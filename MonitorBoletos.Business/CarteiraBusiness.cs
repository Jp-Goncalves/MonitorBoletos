using MonitorBoletos.Model;
using MonitorBoletos.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBoletos.Business
{
    public class CarteiraBusiness
    {
        public Carteira validarCarteira(Carteira carteira)
        {
            var card = new Carteira();

            if (carteira.Numero == 0)
            {
                var inserirCarteira = new CarteiraDAO();
                inserirCarteira.InserirCarteira(carteira);
            }
            else
            {
                var atualizarCarteira = new CarteiraDAO();
                atualizarCarteira.atualizarCarteira(carteira);
            }

            return card;
        }
    }
}
