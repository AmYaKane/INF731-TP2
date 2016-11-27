
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
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
/// </INF731-TP2>

namespace INF731_TP2
{
    #region // Déclaration des classes d'exception
    public class TypeCompteInvalideException : ApplicationException { }
    public class CaractéristiqueCompteInvalideException : ApplicationException { }
    public class StatutCompteInvalideException : ApplicationException { }
    public class MontantNegatifException : ApplicationException { }
    public class MontantNotMultipleValideException : ApplicationException { }
    public class MontantRetraitLimitExceedException : ApplicationException { }
    public class TransactionTypeDeCompteInvalideException : ApplicationException { }

    #endregion

    public abstract class Compte : ICalculateurIntêrét
    {
        #region // Déclaration des Attributs
        public const string CHÈQUE = "chèque";
        public const string FLEXIBLE = "flexible";
        public const string ÉPARGNE = "épargne";
        public const string CONJOINT = "conjoint";
        public const string INDIVIDUEL = "individuel";
        public const string FORFAIT = "forfait";
        public const string PIÈCE = "pièce";
        public const char CODE_ACTIF = 'A';
        public const char CODE_INACTIF = 'I';
        public const double FRAIS_PAR_CHÈQUE = 0.5;
        public const double MAX_RETRAIT_GA = 500;
        public const int MULTIPLE_MONTANT_RGA = 5;
        

        public static readonly string[] TypeCompteValide = { CHÈQUE, ÉPARGNE, FLEXIBLE };
        public static readonly string[] CaractéristiqueCompteValide = { INDIVIDUEL, CONJOINT };
        public static readonly char[] StatutCompteValide = { CODE_ACTIF, CODE_INACTIF };

        //public string[] NuméroClients { get; private set; } 
        public string[] numéroClients = new string[2];
        private string typeDeCompte;
        private string caractéristiqueDeCompte;
        private char statutCompte;
        private double soldeCompte;
        private double soldePlusBas;

        #endregion


        #region // Déclaration des propriétés
        public string[] NuméroClients { get; private set; }

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

        public string TypeDeCompte                          // Setter is private, Cannot be changed by child once created
        {
            get { return typeDeCompte; }

            private set                              
            {
                if (TypeCompteValide.Contains<string>(value))
                {
                    typeDeCompte = value;
                }
                else
                {
                    throw new TypeCompteInvalideException();
                }
            }
        }

        public string CaractéristiqueDeCompte               // Setter is private, Cannot be changed by child once created
        {
            get
            {
                return caractéristiqueDeCompte;
            }
            private set                             
            {
                if (CaractéristiqueCompteValide.Contains<string>(value))
                {
                    caractéristiqueDeCompte = value;
                }
                else
                {
                    throw new CaractéristiqueCompteInvalideException();
                }
            }
        }

        public string NuméroCompte { get; private set; }    // Setter is private, Cannot be changed by child once created
        
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
                    throw new StatutCompteInvalideException();
                }
                
            }
        }

        public double SoldeCompte                   // Setter is protected, Can be changed by child once created
        {
            get { return soldeCompte; }

            protected set                           
            {
                if (value < 0)
                {
                    throw new MontantNegatifException();
                }
                else
                {
                    soldeCompte = value;
                    if (SoldeCompte < SoldePlusBas)
                    {
                        SoldePlusBas = SoldeCompte;
                    }
                }
            }
        }

        public double SoldePlusBas
        {
            get { return soldePlusBas; }

            private set
            {
                if (value < 0)
                {
                    throw new MontantNegatifException();
                }
                else
                {
                    soldePlusBas = value;
                }
            }
        }
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
        public Compte(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte, string numéroCompte, char statutCompte, double soldeCompte)
        {
            if (!TypeCompteValide.Contains(typeDeCompte))
                throw new TypeCompteInvalideException();
            else
            {
                NuméroClients = numéroClient;
                TypeDeCompte = typeDeCompte;
                CaractéristiqueDeCompte = caracteristiqueDeCompte;
                NuméroCompte = numéroCompte;
                StatutCompte = statutCompte;
                SoldePlusBas = soldeCompte;
                SoldeCompte = soldeCompte;
            }
        }

        #endregion


        #region // Déclaration des méthodes

        /// <summary>
        /// Retourne le statut du compte; Actif ou Inactif
        /// </summary>
        /// <returns>
        /// <return> True si le compte est Actif </return>
        /// <return> False si le compte est Inactif </return>
        /// </returns>
        public bool EstActif()
        {
            bool estActif = false;

            if (StatutCompte == CODE_ACTIF)
            {
                estActif = true;
            }
            return estActif;
        }

        /// <summary>
        /// Rendre un compte Actif
        /// </summary>
        /// <returns>
        ///     <return> True si le compte était Inactif et a été rendu Actif </return>
        ///     <return> False si le compte était déjà Actif </return>
        /// </returns>
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

        /// <summary>
        /// Rendre un compte Inactif
        /// </summary>
        /// <returns>
        ///     <return> True si le compte était Actif et a été rendu Inactif </return>
        ///     <return> False si le compte était déjà Inactif </return>
        /// </returns>
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

        /// <summary>
        /// Retourne l'état du compte; Ouvert ou Fermer
        /// </summary>
        /// <returns>
        /// <return> True si le compte est Fermer </return>
        /// <return> False si le compte est Ouvert </return>
        /// </returns>
        public bool EstFermer()
        {
            return CompteFermer;
        }

        /// <summary>
        /// Ferme le compte définitivement
        /// </summary>
        /// <WARNING> Cette action est NON RÉVERSIBLE ! </WARNING>
        /// <returns><return> True si le compte était Ouvert et a été Fermer. </return>
        /// <return> False si le compte était déjà Fermer. </return>
        /// </returns>
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

        public virtual string FormatterCompte()
        {
            return GestionMessages.NUMÉRO_CLIENT + NuméroClients[0] + Environment.NewLine +
                   GestionMessages.NUMÉRO_COMPTE + NuméroCompte + Environment.NewLine +
                   GestionMessages.STATUT_COMPTE + StatutCompte + Environment.NewLine +
                   GestionMessages.SOLDE_COMTE + SoldeCompte;
        }

        /// <summary>
        /// TODO implement by AYK
        /// </summary>
        /// <returns></returns>
        public virtual string ÉcrireClient()
        {
            return ToString(); //  TODO by AYK
        }

        /// <summary>
        /// Reset le solde le plus bas du compte à la valeur du Solde courant du compte.
        /// </summary>
        public void ResetSoldePlusBas()
        {
            SoldePlusBas = SoldeCompte;
        }

        #endregion


        #region // Déclaration des Méthodes Virtual

        /// <summary>
        /// Depot d'un montant dans un compte
        /// <transaction> D </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns>
        /// <return> True si le montant a été déposer dans le compte. </return>
        /// <return> False si le montant n'a pas pu être déposer. </return>
        /// </returns>
        public virtual bool Déposer(double montant)
        {
            if (EstActif())
            {
                //return NuméroCompte + ";" + NuméroClients[0] + ", Numéro de Client2: " + NuméroClients[1] +", Solde du compte: " + SoldeCompte;

                if (montant > 0)
                {
                    SoldeCompte += montant;
                    return true;
                }
                else
                    throw new MontantNegatifException();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Depot d'un montant dans un compte au Guichet Automatique
        /// <transaction> DGA </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns>
        /// <return> True si le montant a été déposer dans le compte. </return>
        /// <return> False si le montant n'a pas pu être déposer. </return>
        /// </returns>
        public virtual bool DéposerGuichetAutomatique(double montant)
        {
            if (Déposer(montant))
                return true;
            else
                return false;
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
        /// Faire des retraits au comptoir
        /// <transaction> R </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns>
        /// <return> True si le montant a été Retiré. </return>
        /// <return> False si le montant n'a pas pu être retiré. </return> 
        /// </returns>
        public virtual bool Retirer(double montant)
        {
            if (EstActif())
            {
                if (montant > 0)
                {
                    if (SoldeCompte >= montant)
                    {
                        SoldeCompte -= montant;
                        return true;
                    }
                    else
                        throw new MontantRetraitLimitExceedException();
                }
                else
                    throw new MontantNegatifException();
            }
            else
                return false;
        }

        /// <summary>
        /// Faire un retrait dans un guichet automatique
        /// <transaction> RGA </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns>
        /// <return> True si le montant a été Retiré. </return>
        /// <return> False si le montant n'a pas pu être retiré. </return> 
        /// </returns>
        public virtual bool RetirerGuichetAutomatique(double montant)
        {
            if (montant < 0)
                throw new MontantNegatifException();

            else if (montant % MULTIPLE_MONTANT_RGA != 0)
                throw new MontantNotMultipleValideException();

            else if (montant >= MAX_RETRAIT_GA)
                throw new MontantRetraitLimitExceedException();

            else if (Retirer(montant))
                return true;

            else
                return false;
        }

        /// <summary>
        /// Faire un retrait par chèque
        /// <transaction> C </transaction>
        /// </summary>
        /// <param name="montant"></param>
        /// <returns>
        /// <return> True si le montant a été Retiré. </return>
        /// <return> False si le montant n'a pas pu être retiré. </return> 
        /// </returns>
        public virtual bool RetirerChèque(double montant)
        {
            if (Retirer(montant + FRAIS_PAR_CHÈQUE))
                return true;  
            else
                return false;
        }

        public abstract double CalculerIntérêts();

        /// <summary>
        /// Ajouter les intérêts sur le compte
        /// </summary>
        /// <returns></returns>
        public virtual bool AjouterIntérêts()
        {
            if (EstActif())
            {
                SoldeCompte += CalculerIntérêts();
                return true;
            }
            else
            {
                return false;
            }
        }
       
        /// <summary>
        /// Afficher le solde du compte
        /// </summary>
        /// <returns></returns>
        public virtual double AfficherSolde()
        {
            return SoldeCompte; 
        }

        /// <summary>
        /// Afficher les informations du compte
        /// </summary>
        public virtual void Afficher()
        {
            Console.Write(ToString());
        }
        
        /// <summary>
        /// Override ToString pour afficher les informations du compte
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (CaractéristiqueDeCompte == CONJOINT)
            {
                return "Numéro de compte: " + NuméroCompte + ", Numéro de Client1: " + NuméroClients[0] + ", Numéro de Client2: " + NuméroClients[1] + ", Solde du compte: " + SoldeCompte;
            }
            else
            {
                return "Numéro de compte: " + NuméroCompte + ", Numéro de Client: " + NuméroClients[0] + ", Solde du compte: " + SoldeCompte;
            }
        }

        //public abstract double CalculerIntérêt();

        #endregion
    }
}