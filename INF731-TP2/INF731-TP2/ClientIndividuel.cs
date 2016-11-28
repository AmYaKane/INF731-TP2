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
///         Classe définissant un client individuel de la banque   
///     </summary>
///     
/// </INF731-TP2>

namespace INF731_TP2
{
    public class ClientIndividuel : Client
    {
        #region // Déclaration des attributs
        #endregion


        #region // Déclaration des propriétés
        public string NomClient { get; private set; }
        public string PrénomClient { get; private set; }
        #endregion


        #region // Déclaration des constructeurs de class

        /// <summary>
        ///     Declaration du constructeur de la classe 
        /// </summary>
        /// <params>
        ///     <param name="numéroClient"></param>
        ///     <param name="nom"></param>
        ///     <param name="prénom"></param>
        /// </params>
        /// <base> numéroClient </base>

        public ClientIndividuel(string numéroClient, string nom, string prénom)
            : base(numéroClient)
        {
            NomClient = nom;
            PrénomClient = prénom;
        }

        #endregion


        #region // Déclaration des méthodes
     
        /// <summary>
        ///     Afficher les informations du client a savoir: le numero,le nom et prenom du client
        /// </summary>
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine(NomClient + ", " + PrénomClient);
        }

        /// <summary>
        ///     Affiche les informations de client en format CSV
        /// </summary>
        /// <returns></returns>
        public override string FormatterOutputJournalClient()
        {
            return NuméroClient + ';' + NomClient + ';' + PrénomClient;
        }

        #endregion
    }
}