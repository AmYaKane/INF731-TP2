using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Amadou Yaya Kane <email> Amadou.Yaya.Kane@USherbrooke.ca </email></auteur>
///     </auteurs>
///     <date_remise> 2016-11-29 </date_remise>
/// 
///     <summary>
///         Classe contrôlant l'accès aux fichiers et la gestion de la structure des données lues et écrites.   
///     </summary>
/// </INF731-TP2>

namespace INF731_TP2
{
    #region // Declaration des exceptions
    #endregion
    public class TransactionMonétaire : Transaction
    {
        #region // Déclaration des propriétés 
        public double Montant { get; private set; }
        #endregion


        #region // Déclaration des constructeurs
        /// <summary>
        ///     Constructeur paramétrique
        /// </summary>
        /// <params>
        ///     <param name="typeTransaction"></param>
        ///     <param name="numéroClient"></param>
        ///     <param name="numéroCompte"></param>
        ///     <param name="montant"></param>
        /// </params>
        /// <base> typeTransaction, numéroClient, numéroCompte </base>
        public TransactionMonétaire(string typeTransaction, string numéroClient, string numéroCompte, double montant)
            : base(typeTransaction, numéroClient, numéroCompte)
        {
            Montant = montant;
        }
        #endregion


        #region // Déclaration des méthodes

        /// <summary>
        ///     Clone une transaction
        /// </summary>
        /// <returns></returns>
        public override Transaction Clone()
        {
            return new Transaction(this.TypeTransaction, this.NuméroClient, this.NuméroCompte);
        }

        /// <summary>
        ///     Afficher une transaction
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine(ToString());
        }
        
        /// <summary>
        ///     Override ToString() pour afficher une transaction
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + ";" + Montant.ToString();
        }

        #endregion
    }
}
