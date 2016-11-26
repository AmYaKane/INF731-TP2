
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    public class CompteÉpargne : Compte
    {
        #region // Déclaration des attributs 

        public const double TAUX_INTÉRÊT_ANNUEL = 2.25;
        private double soldeMoyen;

        #endregion


        #region // Déclaration des propriétés

        public double SoldeMoyen
        {
            get
            { return soldeMoyen; }

            set
            { soldeMoyen = value; }
        }

        #endregion


        #region // Déclaration des constructeurs

        public CompteÉpargne(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte, string numéroCompte, char statutCompte, double soldeCompte)
          : base(numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte)
        {
            if (typeDeCompte != "épargne")
            {
                throw new TypeCompteInvalide();
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


        // Calcul Interets Annuel
        /**
         * 
         */
        public bool AjouterIntérêtsAnnuel()
        {
            if (EstActif())
            {
                double intérêts = soldeMoyen * TAUX_INTÉRÊT_ANNUEL;
                SoldeCompte += intérêts;
                return true;
            }
            else
            {
                return false;
            }

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
        /// Méthode qui permet de calculer l'intérêt du compte
        /// </summary>
        /// <returns></returns>
        public override double CalculerIntérêt()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}