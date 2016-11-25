
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    #region // Déclaration des classes d'exception
    public class TypeCompteInvalide : Exception { }
    public class CaractéristiqueCompteInvalide : Exception { }
    public class StatutCompteInvalide : Exception { }

    #endregion

    public abstract class Compte : ICalculateurIntêrét
    {
        #region // Déclaration des Attributs
        public static readonly string[] TypeCompteValide = { "chèque", "épargne", "flexible" };
        public static readonly string[] CaractéristiqueCompteValide = { "individuel", "conjoint" };
        public static readonly char[] StatutCompteValide = { 'A', 'I' };

        public const char CODE_ACTIF = 'A';
        public const char CODE_INACTIF = 'I';
        public const double MAX_RETRAIT_GA = 500; 

        //public string[] NuméroClients { get; private set; } 
        public string[] NuméroClients = new string[2];
        private string typeDeCompte;
        private string caractéristiqueDeCompte;
        private string numéroCompte;
        private char statutCompte;
        private double soldeCompte;

        #endregion


        #region // Déclaration des propriétés

        private bool CompteFermer { get;  set; }

        public int Indice { get; private set; }     // Les classes enfants ont besoin de connaître l'indice du tableauÉléments du constructeur

        public string this[int indice]
        {
            get { return NuméroClients[indice]; }

            private set                              // Setter is private, Cannot be changed by child once created
            {
                NuméroClients[indice] = value;
            }
        }

        public string TypeDeCompte
        {
            get { return typeDeCompte; }

            private set                              // Setter is private, Cannot be changed by child once created
            {
                if (TypeCompteValide.Contains<string>(value))
                {
                    typeDeCompte = value;
                }
                else
                {
                    throw new TypeCompteInvalide();
                }
            }
        }

        public string CaractéristiqueDeCompte
        {
            get
            {
                return caractéristiqueDeCompte;
            }
            private set                             // Setter is private, Cannot be changed by child once created
            {
                if (CaractéristiqueCompteValide.Contains<string>(value))
                {
                    caractéristiqueDeCompte = value;
                }
                else
                {
                    throw new CaractéristiqueCompteInvalide();
                }
            }
        }

        public string NuméroCompte
        {
            get { return numéroCompte; }

            private set                             // Setter is private, Cannot be changed by child once created
            {
                numéroCompte = value;
            }
        }

        public char StatutCompte
        {
            get
            {
                return statutCompte;
            }
            protected set                           // Setter is protected, Can be changed by child once created
            {
                if (StatutCompteValide.Contains<char>(value))
                {
                    statutCompte = value;
                }
                else
                {
                    throw new StatutCompteInvalide();
                }
                
            }
        }

        public double SoldeCompte
        {
            get { return soldeCompte; }

            protected set                           // Setter is protected, Can be changed by child once created
            {
                soldeCompte = value;
            }
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
         */
        public Compte(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte,
        string numéroCompte, char statutCompte, double soldeCompte)
        {
            
                NuméroClients = numéroClient;
                TypeDeCompte = typeDeCompte;
                CaractéristiqueDeCompte = caracteristiqueDeCompte;
                NuméroCompte = numéroCompte;
                StatutCompte = statutCompte;
                SoldeCompte = soldeCompte;
        }
        
        #endregion


        #region // Déclaration des méthodes

        /**
        * 
        */
        public bool RendreActif()
        {
            if (StatutCompte == CODE_ACTIF)
                return false;
            else
            {
                StatutCompte = CODE_ACTIF;
                return true;
            }
        }

        /**
        * 
        */
        public bool RendreInactif()
        {
            if (StatutCompte == CODE_INACTIF)
                return false;
            else
            {
                StatutCompte = CODE_INACTIF;
                return true;
            }
        }

        /**
        * @return bool (True=Actif, False=Inactif)
        */
        public bool EstActif()
        {
            bool estActif = false;

            if (StatutCompte == CODE_ACTIF)
            {
                estActif = true;
            }
            return estActif;
        }

        public bool EstFermer()
        {
            return CompteFermer;
        }

        public bool FermerCompte()
        {
            if (EstFermer())
            {
                return false;
            }
           else
            {
                CompteFermer = true;
                return true; 
            }
           
        }

        public virtual void Afficher()
        {
            Console.Write(ToString());
        }

        public override string ToString()
        {
            if (CaractéristiqueDeCompte == "conjoint")
            {
                return "Numéro de compte: " + NuméroCompte + ", Numéro de Client1: " + NuméroClients[0] + ", Numéro de Client2: " + NuméroClients[1] +", Solde du compte: " + SoldeCompte;
            }
            else
            {
                return "Numéro de compte: " + NuméroCompte + ", Numéro de Client: " + NuméroClients[0] + ", Solde du compte: " + SoldeCompte;
            }
        }

        #endregion


        #region // Déclaration des Méthodes Virtual
      
        /// <summary>
        /// Depot d'un montant dans un compte
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public virtual bool Déposer(double montant)
        {
            return false; // To implement
        }


       /// <summary>
       /// Faire des retraits au comptoir
       /// </summary>
       /// <param name="montant"></param>
       /// <returns></returns>
        public bool RetirerComptoir(double montant)
        {
            if (EstActif())
            {
                //double frais;
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

            //return false; // To implement
        }

        
        /// <summary>
        /// Faire un retrait dans un guichet automatique
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public virtual bool RetirerGuichetAutomatique(double montant)
        {
            // Le retrait doit être un multiple de 5 modulo 0 ou (5 % 0)
            // Le retrait est d'un maximum de 500$

            return false; // To implement
        }


        /// <summary>
        /// Faire un retrait Chèque 
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public virtual bool RetirerChèque(double montant)
        {
            return false; // To implement
        }

      
        /// <summary>
        /// Ajouter les interets
        /// </summary>
        /// <returns></returns>
        public virtual bool AjouterIntérêt()
        {
            return false; // To implement
        }

       
        /// <summary>
        /// Afficher le solde du compte
        /// </summary>
        /// <returns></returns>
        public virtual double AfficherSolde()
        {
            return SoldeCompte; // To implement
        }

        public abstract double CalculerIntérêt();

        #endregion
    }
}