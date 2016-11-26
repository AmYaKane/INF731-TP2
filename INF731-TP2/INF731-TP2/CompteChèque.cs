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
        /// Constructeur paramétrique
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <param name="typeDeCompte"></param>
        /// <param name="caracteristiqueDeCompte"></param>
        /// <param name="numéroCompte"></param>
        /// <param name="statutCompte"></param>
        /// <param name="soldeCompte"></param>
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
                double intérêts = soldePlusBas * TAUX_INTÉRÊT_ANNUEL;
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
        public override double AfficherSolde()
=======
        // To Review 
        // Logique de fin de Mois à gérer au niveau des transactions.
        /// <summary>
        /// Retirer un montant par Chèque
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        //public override bool RetirerChèque(double montant)
        //{
        //    if (EstActif())
        //    {
        //        if (SoldePlusBas < MINIMUM_SOLDE)
        //            if (Retirer(montant + FRAIS_PAR_CHÈQUE))
        //                return true;
        //            else
        //                return false;
        //        else
        //            if (Retirer(montant))
        //                return true;
        //            else
        //                return false;
        //    }
        //    else
        //        return false;
        //}
        
        /// <summary>
        /// Calculer l'intérêt basé sur le solde le plus bas
        /// </summary>
        /// <returns> Intérêts à appliquer sur le compte. </returns>
        public override double CalculerIntérêts()
>>>>>>> 7e1d97f9201d5263933d2bc4d971e229e9b9f93e
        {
            return SoldePlusBas * TAUX_INTÉRÊT_ANNUEL;
        }

<<<<<<< HEAD
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
        /// Méthode qui permet de calculer l'intérêt pour un solde
        /// </summary>
        /// <returns></returns>
        public override double CalculerIntérêt()
=======
        /// <summary>
        /// Afficher les informations de compte
        /// </summary>
        public override void Afficher()
>>>>>>> 7e1d97f9201d5263933d2bc4d971e229e9b9f93e
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}