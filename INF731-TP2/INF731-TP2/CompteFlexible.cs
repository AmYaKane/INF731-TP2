﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    #region // Déclaration des classes d'exception
    public class ModeFacturationInvalide : Exception { }
    #endregion

    public class CompteFlexible : Compte
    {
        #region // Déclaration des Attributs
        public static readonly string[] ModeFacturationValide = { "forfait", "pièce" };

        public const double TAUX_INTÉRÊT_ANNUEL = 1.25;
        public const double MARGE_CRÉDIT_MIN = 3000;
        public const double INTÉRÊT_CRÉDIT_ANNUEL = 7.95;
        public const double FRAIS_PIÉCE = 0.60;
        public const double FRAIS_FORFAIT_FIXE = 9;

        private double montantMarge = 3000;
        private double soldeMarge;
        private string modeFacturation;
        private double soldePlusBas;

        #endregion


        #region // Déclaration des propriétés

        public double MontantMarge
        {
            get { return montantMarge; }
            set { montantMarge = value; }
        }

        public double SoldeMarge
        {
            get { return soldeMarge; }
            set { soldeMarge = value; }
        }

        public string ModeFacturation
        {
            get { return modeFacturation; }

            set { 
                    if (ModeFacturationValide.Contains<string>(value))
                    {
                        modeFacturation = value;
                    }
                    else
                    {
                        throw new ModeFacturationInvalide();
                    }
                }
        }

        public double SoldePlusBas
        {
            get { return soldePlusBas; }
            set { soldePlusBas = value; }
        }

        #endregion


        #region // Déclaration des constructeurs

        /**
         * Constructeur paramétrique
         *
         * @param numéroDeCompte
         * @param ListeDeClient
         * @param typeDeCompte
         * @param caracteristiqueDeCompte
         * @param statutCompte
         * @param soldeCompte
         * @param modeFacturation
         * @param montantMarge
         * @param soldeMarge
         */
        public CompteFlexible(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte,
                            string numéroCompte, char statutCompte, double soldeCompte, string modeFacturation, double montantMarge, double soldeMarge)
            : base(numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte)
        {
            if (typeDeCompte == "flexible")
            {
                ModeFacturation = modeFacturation;
                MontantMarge = montantMarge;
                SoldeMarge = soldeMarge;
            }
            else
            {
                throw new TypeCompteInvalide();
            } 
        }

        #endregion


        #region // Déclaration des méthodes

        /**
         * Description: 
         * @param montant
         * @return 
         */
        public bool EstDécouvert(double montantRetrait, double montantDisponible)  // Donner a la methode un nom avec un verbe
        {
            if (EstActif())
            {
                return false; // To implement
            }
            else
            {
                return false;
            }
        }

        /**
         * 
         */
        public bool AjouterSolde(double soldeMarge, double decouvert)
        {
            if (EstActif())
            {
                return false; // To implement
            }
            else
            {
                return false;
            }
        }

        /**
         * 
         */
        public override bool RetirerComptoir(double retrait)
        {
            if (EstActif())
            {
                return false; // To implement
            }
            else
            {
                return false;
            }
        }

        /**
         * 
         */
        public override bool RetirerGuichetAutomatique(double retrait)
        {
            if (EstActif())
            {
                return false; // To implement
            }
            else
            {
                return false;
            }
        }

        /**
         * 
         */
        public override bool RetirerChèque(double retrait)
        {
            if (EstActif())
            {
                return false; // To implement
            }
            else
            {
                return false;
            }
        }

        /**
         * Description: 
         * @param montant
         * @return 
         */
        public override bool Déposer(double montant)
        {
            if (EstActif())
            {
                SoldeCompte += montant;
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * 
         */
        public bool AjouterIntérêtsAnnuel()
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
        * Méthode: Afficher()
        * @param 
        */
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine(", Mode de Facturation: " + ModeFacturation + ", Montant Marge: " + MontantMarge + ", Solde Marge: " + SoldeMarge);
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
