using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
///         <auteur> Bassir Diallo <email> albassir02@gmail.com </email></auteur>
///         <auteur> Sory DIANE <email> sorydian2@gmail.com </email></auteur>
///         <auteur> Francoise Askoum Koumtingue <email> askoumk@gmail.com </email></auteur>
///     </auteurs>
/// 
///     <summary>
///         Classe définissant les comptes de type Chèque de la banque.
///     </summary>
///     
///     <méthodes>
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
///     </méthodes>
/// </INF731-TP2>

namespace INF731_TP2
{
    
    #region // Déclaration des classes d'exception
    #endregion

    public class CompteChèque : Compte

	{
        #region // Déclaration des attributs

        public const double MINIMUM_SOLDE = 1000;
        public const double TAUX_INTÉRÊT_ANNUEL = 0.005;

        #endregion


        #region // Déclaration des propriétés
        #endregion


        #region // Déclaration des constructeurs

        /// <summary>
        ///     Constructeur paramétrique
        /// </summary>
        /// <params>
        ///     <param name="numéroClient"></param>
        ///     <param name="typeDeCompte"></param>
        ///     <param name="caracteristiqueDeCompte"></param>
        ///     <param name="numéroCompte"></param>
        ///     <param name="statutCompte"></param>
        ///     <param name="soldeCompte"></param>
        /// </params>
        /// <Base numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte></Base>
        public CompteChèque(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte,
                            string numéroCompte, char statutCompte, double soldeCompte)
            : base(numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte)
        {
            if (typeDeCompte != CHÈQUE)
            {
                throw new TypeCompteInvalideException();
            }
        }

        #endregion


        #region // Déclaration des méthodes

        //  To Review 
        //  Logique de fin de Mois à gérer au niveau des transactions.
        /// <summary>
        ///     Retirer un montant par Chèque
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public override bool RetirerChèque(double montant)
        {
            if (EstActif())
            {
                //if (SoldePlusBas < MINIMUM_SOLDE)
                //    if (Retirer(montant + FRAIS_PAR_CHÈQUE))
                //        return true;
                //    else
                //        return false;
                //else
                if (Retirer(montant))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        ///     Virement / paiement de la marge de crédit du compte
        /// </summary>
        /// <param name="montant"></param>
        /// <returns>
        ///     <return> Retourne une Exception TransactionTypeDeCompteInvalideException </return>
        /// </returns>
        public override bool VirementMarge(double paiement)
        {
            throw new TransactionTypeDeCompteInvalideException();
        }

        /// <summary>
        ///     Calculer l'intérêt basé sur le solde le plus bas
        /// </summary>
        /// <returns> Intérêts à appliquer sur le compte. </returns>
        public override double CalculerIntérêts()
        {
            return SoldePlusBas * TAUX_INTÉRÊT_ANNUEL;
        }

        /// <summary>
        /// Afficher les informations de compte
        /// </summary>
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine();
        }

        #endregion
    }
}