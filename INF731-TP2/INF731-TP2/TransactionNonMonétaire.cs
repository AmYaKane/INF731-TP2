using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF731_TP2
{
    public class TransactionNonMonétaire : Transaction
    {
        public TransactionNonMonétaire(string typeTransaction, string numéroClient, string numéroCompte)
             : base(typeTransaction, numéroClient, numéroCompte)
        {

        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine();
        }

        public override Transaction Clone()
        {
            return new Transaction(this.TypeTransaction, this.NuméroClient, this.NuméroCompte);
        }
    }
}
