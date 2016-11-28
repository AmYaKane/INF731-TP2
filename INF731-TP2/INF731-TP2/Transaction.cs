﻿using System;
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
    public class Transaction
    {
        #region // Déclaration des propriétés

        public string TypeTransaction { get; private set; }
        public string NuméroClient { get; private set; }
        public string NuméroCompte { get; private set; }

        #endregion


        #region // Déclaration des constructeurs

        /// <summary>
        ///     Constructeur parmétrique
        /// </summary>
        /// <params>
        ///     <param name="typeTransaction"></param>
        ///     <param name="numéroClient"></param>
        ///     <param name="numéroCompte"></param>
        /// </params>
        public Transaction(string typeTransaction, string numéroClient, string numéroCompte)
        {
            TypeTransaction = typeTransaction;
            NuméroClient = numéroClient;
            NuméroCompte = numéroCompte;
        }
        #endregion


        #region // Déclaration des méthodes
        public virtual Transaction Clone()
        {
            return new Transaction(this.TypeTransaction, this.NuméroClient, this.NuméroCompte);
        }

        public virtual void Afficher()
        {
            Console.Write(ToString());
        }
        
        public override string ToString()
        {
            return TypeTransaction + ";" + NuméroClient + ";" + NuméroCompte.ToString();
        }

        #endregion
    }
}
