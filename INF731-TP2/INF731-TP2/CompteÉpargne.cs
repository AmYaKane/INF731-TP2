﻿using System;
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
///         Classe définissant les comptes de type Épargne de la banque.
///     </summary>
///     
/// </INF731-TP2>

namespace INF731_TP2
{
    #region // Declaration des exceptions
    #endregion

    public class CompteÉpargne : Compte
    {
        #region // Déclaration des attributs 

        public const double TAUX_INTÉRÊT_ANNUEL = 0.0225;
        private double soldeMoyen;

        #endregion


        #region // Déclaration des propriétés
        public double SoldeMoyen                // Doit être calculer à partir des Transactions
        {
            get { return soldeMoyen; }
            private set
            {
                if (value < 0)
                    throw new MontantNegatifException();
                else
                    SoldeMoyen = value;
            }
        }
        #endregion


        #region // Déclaration des constructeurs

        /// <summary>
        /// Constructeur paramétrique
        /// </summary>
        /// <params>
        ///     <param name="numéroClient"></param>
        ///     <param name="typeDeCompte"></param>
        ///     <param name="caracteristiqueDeCompte"></param>
        ///     <param name="numéroCompte"></param>
        ///     <param name="statutCompte"></param>
        ///     <param name="soldeCompte"></param>
        /// </params>
        /// <base numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte ></base>
        public CompteÉpargne(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte, string numéroCompte, char statutCompte, double soldeCompte)
          : base(numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte)
        {
            if (typeDeCompte != ÉPARGNE)
            {
                throw new TypeCompteInvalideException();
            }
        }

        #endregion


        #region // Déclaration des Methodes

        // méthode dépot montant
        /**
         * 
         */
        //public override bool Déposer(double montant)
        //{
        //    if (EstActif())
        //    {
        //        base.SoldeCompte += montant;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        /// <summary>
        ///     Transaction non supporter par compte Épargne
        ///     <transaction> DGA </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns> TransactionTypeDeCompteInvalideException </returns>
        public override bool DéposerGuichetAutomatique(double montant)
        {
            throw new TransactionTypeDeCompteInvalideException();
        }

        /// <summary>
        ///     Transaction non supporter par compte Épargne
        ///     <transaction> RGA </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns> TransactionTypeDeCompteInvalideException </returns>
        public override bool RetirerGuichetAutomatique(double montant)
        {
            throw new TransactionTypeDeCompteInvalideException();
        }

        /// <summary>
        ///     Transaction non supporter par compte Épargne
        ///     <transaction> C </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns> TransactionTypeDeCompteInvalideException </returns>
        public override bool RetirerChèque(double montant)
        {
            throw new TransactionTypeDeCompteInvalideException();
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
        ///     Calculer l'intérêt basé sur le solde moyen du compte
        /// </summary>
        /// <returns> Intérêts à appliquer sur le compte. </returns>
        public override double CalculerIntérêts()
        {
            return SoldeMoyen * TAUX_INTÉRÊT_ANNUEL;
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
        ///     Afficher les informations de compte
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
            string output = "";
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