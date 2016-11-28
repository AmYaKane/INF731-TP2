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

<<<<<<< HEAD
        //  To Review 
        //  Logique de fin de Mois à gérer au niveau des transactions.
=======
        /*
        * Méthode: Déposer
        * @param double montant
        */
        public override bool Déposer(double montant)
        {
            if (EstActif())
            {
                base.SoldeCompte += montant;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        * Méthode: RetirerComptoir
        * @param double montant
        */
        //public override bool RetirerComptoir(double montant)
        //{
        //    if (EstActif())
        //    {
        //        //double frais;
        //        if (SoldeCompte >= montant)
        //        {
        //            SoldeCompte -= montant;
        //            return true;
        //        }
        //        else
        //        {
        //            // Throw new exception
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /*
         * Méthode: RetirerGuichetAutomatique
         * @param double montant
         */
        public override bool RetirerGuichetAutomatique(double montant)
        {
            if (EstActif())
            {
                //double frais;
                if (montant <= MAX_RETRAIT_GA)
                {
                    if (SoldeCompte >= montant)
                    {
                        SoldeCompte -= montant;
                        return true;
                    }
                    else
                    {
                        // Throw new exception
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /*
         * Méthode: RetirerChèque
         * @param double montant
         */
        public override bool RetirerChèque(double montant)
        {
            if (EstActif())
            {
                //double frais;
                if (SoldeCompte >= montant)
                {
                    if (SoldeCompte < MINIMUM_SOLDE)
                    {
                        montant += FRAIS_PAR_CHÈQUE;
                    }

                    SoldeCompte -= montant;
                    return true;
                }
                else
                {
                    // Throw new exception
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
            
        /*
         * Méthode: AjouterIntérêtsAnnuel
         * @param 
         */

        public bool AjouterIntérêtl()
        {
            if (EstActif())
            {
                double intérêts = SoldePlusBas * TAUX_INTÉRÊT_ANNUEL;
                SoldeCompte += intérêts;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Méthode: ToString
         * @param double montant
         */
        //public override double AfficherSolde()
        //{ }
        // To Review 
        // Logique de fin de Mois à gérer au niveau des transactions.
>>>>>>> e7f93f33f6840b3db8458da4610c4ddd215026c9
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

        /*
        * Méthode: Afficher()
        * @param 
        */
        public override string FormatterCompte()
        {
           return base.FormatterCompte();
            //Console.WriteLine();
        }

        /// <summary>
        /// Afficher les informations de compte
        /// </summary>
        public override void Afficher()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Affiche les informations de compte en format CSV
        /// </summary>
        /// <returns></returns>
        public override string FormatterOutputJournalCompte()     
        {
            string output="";
            switch (CaractéristiqueDeCompte)
            {
                case INDIVIDUEL:
                    output = NuméroClients[0] + ';' + TypeDeCompte + ';' + CaractéristiqueDeCompte + ';' + NuméroCompte + ';' + StatutCompte + ';' + SoldeCompte;
                    break;
                case FLEXIBLE:
                    output = NuméroClients[0] + ';' + TypeDeCompte + ';' + CaractéristiqueDeCompte + ';' + NuméroClients[1] + ';' + NuméroCompte + ';' + StatutCompte + ';' + SoldeCompte;
                    break;
            }
            return output;
        }   

        #endregion
    }
}