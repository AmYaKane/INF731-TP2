using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INF731_TP2
{
    
    #region // Déclaration des classes d'exception
    class MontantNegatifException : ApplicationException { }
    #endregion

    public class CompteChèque : Compte

	{
        #region // Déclaration des attributs

        public const double FRAIS_PAR_CHÈQUE = 0.50;
        public const double MINIMUM_SOLDE = 1000;
        public const double TAUX_INTÉRÊT_ANNUEL = 0.5;

        private double soldePlusBas;
		private double leTauxIntérêtAnnuel;

        #endregion


        #region // Déclaration des propriétés

        public double SoldePlusBas 
		{
			get 
			{ 
				return soldePlusBas;
			}

	        private set
			{
                if (soldePlusBas < 0)
                {
                    throw new MontantNegatifException();
                }
                else
                {
                    soldePlusBas = value;
                }
            }
		}

		public double LeTauxIntérêtAnnuel
			{
				get 
				{ 
					return leTauxIntérêtAnnuel;
				}
			
				private set
				{
                if (leTauxIntérêtAnnuel < 0)
                {
                    throw new MontantNegatifException();
                }
                else
                {
                    leTauxIntérêtAnnuel = value;
                }
            }
		}

        #endregion


        #region // Déclaration des constructeurs

        // Renvoit tout les paramètres au parent
        public CompteChèque(string[] numéroClient, string typeDeCompte, string caracteristiqueDeCompte,
                            string numéroCompte, char statutCompte, double soldeCompte)
            : base(numéroClient, typeDeCompte, caracteristiqueDeCompte, numéroCompte, statutCompte, soldeCompte)
        {
            if (typeDeCompte != "chèque")
            {
                throw new TypeCompteInvalide();
            }
        }

        #endregion


        #region // Déclaration des méthodes

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
        {
            if (EstActif())
            {
                return SoldeCompte;
            }
            else
            {
                throw new Exception();   // To implement
            }
            
        }

        /*
        * Méthode: Afficher()
        * @param 
        */
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine();
        }

        /// <summary>
        /// Méthode qui permet de calculer l'intérêt pour un solde
        /// </summary>
        /// <returns></returns>
        public override double CalculerIntérêt()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}