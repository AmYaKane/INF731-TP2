using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
///     </auteurs>
/// 
///     <summary>
///         Classe définissant les clients de la banque.   
///     </summary>
///     
/// </INF731-TP2>

namespace INF731_TP2
{
    public abstract class Client
    {

        #region // Déclaration des attributs
        public string NuméroClient { get; private set; }
        #endregion


        #region // Déclaration des propriétés
        #endregion


        #region // Déclaration des constructeurs de class

        public Client(string numéroClient)
        {
            NuméroClient = numéroClient;
        }

        #endregion


        #region // Déclaration des méthodes


        /// <summary>
        ///     Affiche numéro du client
        /// </summary>
        public virtual void Afficher()
        {
            Console.Write(ToString());
        }

        /// <summary>
        ///     Surcharge ToString pour afficher les propriétés du client
        /// </summary>
        /// <returns> NuméroClient " - " </returns>
        public override string ToString()
        {            
            return NuméroClient + " - ";
        }

        /// <summary>
        ///     Affiche les informations de client en format CSV
        /// </summary>
        /// <returns></returns>
        public abstract string FormatterOutputJournalClient();


        #endregion
    }
}