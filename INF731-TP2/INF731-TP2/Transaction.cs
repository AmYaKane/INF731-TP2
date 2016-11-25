using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF731_TP2
{
    public class Transaction
    {
        public string TypeTransaction { get; private set; }
        public string NuméroClient { get; private set; }
        public string NuméroCompte { get; private set; }


        public Transaction(string typeTransaction, string numéroClient, string numéroCompte)
        {
            TypeTransaction = typeTransaction;
            NuméroClient = numéroClient;
            NuméroCompte = numéroCompte;
        }

        public override string ToString()
        {
            return TypeTransaction + ";" + NuméroClient + ";" + NuméroCompte.ToString();
        }

        public virtual void Afficher()
        {
            Console.Write(ToString());
        }

        public virtual Transaction Clone()
        {
            return new Transaction(this.TypeTransaction, this.NuméroClient, this.NuméroCompte);
        }
    }
}
