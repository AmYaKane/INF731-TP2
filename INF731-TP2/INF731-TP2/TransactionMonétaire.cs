using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF731_TP2
{
    public class TransactionMonétaire : Transaction
    {
        public double Montant { get; private set; }

        public TransactionMonétaire(string typeTransaction, string numéroClient, string numéroCompte, double montant)
            : base(typeTransaction, numéroClient, numéroCompte)
        {
            Montant = montant;
        }

        public override string ToString()
        {
            return  base.ToString() + ";" + Montant.ToString();
        }
        public override void Afficher()
        {
            Console.WriteLine(ToString());
        }

        public override Transaction Clone()
        {
            return new Transaction(this.TypeTransaction, this.NuméroClient, this.NuméroCompte);
        }
    }
}
