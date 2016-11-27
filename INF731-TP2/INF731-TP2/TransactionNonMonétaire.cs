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
///     
///      <méthodes>
///         <méthode> 
///             <Nom> ParseCSV(string ligne) </Nom>
///             <Description> Lit une ligne csv et créer un Array de string </Description>
///         </méthode>
///         <méthode>
///             <Nom> loadClients(String cheminFichier) </Nom>
///             <Description> </Description>
///         </méthode>
///         <méthode>
///             <Nom> </Nom>
///             <Description> </Description>
///         </méthode>
///         <méthode>
///             <Nom> </Nom>
///             <Description> </Description>
///         </méthode>
///         <méthode>
///             <Nom> </Nom>
///             <Description> </Description>
///         </méthode>
///         <méthode>
///             <Nom> </Nom>
///             <Description> </Description>
///         </méthode>
///         <méthode>
///             <Nom> </Nom>
///             <Description> </Description>
///         </méthode>
///         <méthode>
///             <Nom> </Nom>
///             <Description> </Description>
///         </méthode>
///      </méthodes>

namespace INF731_TP2
{
    #region // Declaration des exceptions
    #endregion
    public class TransactionNonMonétaire : Transaction
    {
        #region // Déclaration des constructeurs

        /// <summary>
        ///     Constructeur paramétrique
        /// </summary>
        /// <params>
        ///     <param name="typeTransaction"></param>
        ///     <param name="numéroClient"></param>
        ///     <param name="numéroCompte"></param>
        /// </params>
        /// <base> typeTransaction, numéroClient, numéroCompte </base>
        public TransactionNonMonétaire(string typeTransaction, string numéroClient, string numéroCompte)
             : base(typeTransaction, numéroClient, numéroCompte)
        {

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
        ///     Affiche une transaction
        /// </summary>
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine();
        }

        #endregion
    }
}
