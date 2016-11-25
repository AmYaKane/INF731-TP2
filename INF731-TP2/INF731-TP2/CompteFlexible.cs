<<<<<<< HEAD
<<<<<<< HEAD
﻿//// Entry point name must be "Solution"
//using System;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

///**
// * 
// */
//namespace INF731_TP2
//{
//    public class CompteFlexible : Compte
//    {
//        // Déclaration des Attributs

//        private const double TAUX_INTÉRÊT_ANNUEL = 1.25;
//        private const double MARGE_CRÉDIT_MIN = 3000;
//        private const double INTÉRÊT_CRÉDIT_ANNUEL = 7.95;
//        private const double FRAIS_PIÉCE = 0.60;
//        private const double FRAIS_FORFAIT_FIXE = 9;

//        private double montantMarge = 3000;
//        private double soldeMarge;
//        private string modeFacturation;
//        private double soldePlusBas;


//        // Déclaration des propriétés

//        public double MontantMarge
//        {
//            get { return montantMarge; }
//            set { montantMarge = value; }
//        }

//        public double SoldeMarge
//        {
//            get { return soldeMarge; }
//            set { soldeMarge = value; }
//        }

//        public string ModeFacturation
//        {
//            get { return modeFacturation; }
//            set { modeFacturation = value; }
//        }

//        public double SoldePlusBas
//        {
//            get { return soldePlusBas; }
//            set { soldePlusBas = value; }
//        }


//        // Déclaration des constructeurs

//        /**
//         * Constructeur paramétrique
//         *
//         * @param numéroDeCompte
//         * @param ListeDeClient
//         * @param typeDeCompte
//         * @param caracteristiqueDeCompte
//         * @param statutCompte
//         * @param soldeCompte
//         * @param montantMarge
//         * @param soldeMarge
//         * @param modeFacturation
//         * @param soldePlusBas
//         */

//        public CompteFlexible(string[] tableauDesÉléments) 
//            : base(tableauDesÉléments)
//        {
//            MontantMarge = double.Parse(tableauDesÉléments[base.Indice + 7]);
//            SoldeMarge = double.Parse(tableauDesÉléments[base.Indice + 8]);
//            double montantMarge; double soldeMarge; string modeFacturation;

//        }


//        // Déclaration des méthodes

//        /**
//         * Description: 
//         * @param montant
//         * @return 
//         */

//        solde = 1000;
//        marge = 3000;
//        retrait = 1500;

//        retrait - solde = 500;
//        marge - retrait = 2500 sur 3000;

//        Si soldeMarge<montantMarge Alors, SoldeCompte == 0


//        public double montantdécouvert(double montantRetrait, double montantDisponible)
//        {
//            double montantMarge;

//            if (montantRetrait > montantDisponible)
//            {
//                montantMarge = Abs(montantDisponible - montantRetrait);
//            }
//            return montantMarge;
//        }

//        public void ajouterSolde(double soldeMarge, double decouvert)
//        {

//        }
//        public override bool Retirer(double retrait)
//        {




//            retrait
//            montantMarge
//            montantdécouvert










//            montantDisponible = SoldeCompte


//            if (soldeCompte >= montant)
//            {
//                soldeCompte -= montant;
//                return true;
//            }
//            else if (soldeMarge < montantMarge && (montantMarge - soldeMarge) <= montant)
//            {
//                montantDisponible = montantMarge - soldeMarge
//                retrait(montantRetrait, montantDisponible)


//                soldeMarge -= montant;
//                return true;
//            }
//            else (soldeMarge -
//            {
//                soldeMarge -= montant;
//            }
//            else if (solde <
//            {
//            }
//        }

//        /**
//         * Description: 
//         * @param montant
//         * @return 
//         */

//        public override bool Déposer(double montant)
//        {

//            if (soldeCompte >= montant)
//            {
//                soldeCompte += montant;
//                return true;
//            }
//            else
//                return false;
//        }

//        public void AjouterIntérêtsAnnuel()
//        {
//            double intérêts = soldePlusBas * TAUX_INTÉRÊT_ANNUEL;
//            soldePlusBas += intérêts;
//        }
//    }
//}
=======
﻿using System;
=======
﻿﻿using System;
>>>>>>> f580a0f478466bf789b1a8a4b69ad02a1c1c83ea
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

        public double SoldePlusBas { get; private set; }
        //{
        //    get
        //    {
        //        //soldePlusBas = this.SoldeCompte;
        //        if (soldePlusBas < this.SoldeCompte) { soldePlusBas = this.SoldeCompte; }
        //        return Math.Min(soldePlusBas, this.SoldeCompte) ;
        //    }
        //    private set;      
        //}

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
                SoldePlusBas = SoldeCompte;
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
        //public override bool RetirerComptoir(double montant)
        //{
        //    //if (EstActif())
        //    //{
        //    //    return false; // To implement
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}

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
               // double intérêts = soldePlusBas * TAUX_INTÉRÊT_ANNUEL;
                SoldeCompte += CalculerIntérêt();
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
            Console.WriteLine(", Mode de Facturation: " + ModeFacturation + ", Montant Marge: " + MontantMarge + ", Solde Marge: " + SoldeMarge + ", Solde Plus Bas: " + SoldePlusBas);
        }

        /// <summary>
        /// Méthode qui permet de calculer l'intérêt du compte
        /// </summary>
        /// <returns></returns>
        public override double CalculerIntérêt()
        {
            return soldePlusBas * TAUX_INTÉRÊT_ANNUEL;
        }


        public void ModifierSolde(double nouveauSolde)
        {          
           
            SoldeCompte = nouveauSolde;
            
            if (SoldePlusBas > SoldeCompte) { SoldePlusBas = SoldeCompte; }

        }

        #endregion
    }
}
<<<<<<< HEAD
>>>>>>> 93f67e978dbf7802213772d7dde1c5becc9f6b14
=======
>>>>>>> f580a0f478466bf789b1a8a4b69ad02a1c1c83ea
