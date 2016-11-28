using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <INF731-TP2>
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
///         <auteur> Amadou Yaya Kane <email> Amadou.Yaya.Kane@USherbrooke.ca </email></auteur>
///     </auteurs>
///     <date_remise> 2016-11-29 </date_remise>
/// 
///     <summary>
///         Classe contrôlant l'accès aux fichiers et la gestion de la structure des données lues et écrites.   
///     </summary>
///     
/// </INF731-TP2>

#region // Déclaration des classes d'exception
#endregion
namespace INF731_TP2
{
    public class Banque : IOpérateurTransaction
    {
        #region // Déclaration des attributs

        private string nomBanque;
        public List<Client> ListeDeClients { get; set; } // Propriété automatique
        public List<Compte> ListeDeComptes { get; set; } // Propriété automatique
        public List<Transaction> ListeTransactions { get; set; } // Propriété automatique
        public List<Exception> ListeExceptions { get; set; }
        string [] listetypeTransaction = new string [] {"D", "DGA", "R", "RGA", "C", "VM", "I", "A", "S"};
        #endregion


        #region // Déclaration des propriétés

        public string NomBanque
        {
            get { return nomBanque; }
            private set { nomBanque = value; }
        }

        #endregion


        #region // Déclaration des constructeurs de class

        /// <summary>
        ///     Déclaration du constructeur paramétrique
        /// </summary>
        /// <param name="nomBanque"></param>
        public Banque(string nomBanque)
        {
            NomBanque = nomBanque;
            ListeDeClients = new List<Client>();
            ListeDeComptes = new List<Compte>();
            ListeTransactions = new List<Transaction>();
            ListeExceptions = new List<Exception>();
        }

        #endregion


        #region // Déclaration des méthodes

        /// <summary>
        ///     Ajouter un client dans la liste des clients de la banque
        /// </summary>
        /// <param name="client"></param>
        public bool AjouterClient(Client client)
        {
            if (TrouverClient(client.NuméroClient) == null)
            {
                ListeDeClients.Add(client);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        ///     Ajouter un compte dans la liste des comptes de la banque
        /// </summary>
        /// <param name="compte"></param>
        public bool AjouterCompte(Compte compte)
        {
            foreach (Compte c in TrouverLesComptes(compte.NuméroClients[0]))
            {
                if (c.CaractéristiqueDeCompte == compte.CaractéristiqueDeCompte)
                {
                    if (c.TypeDeCompte == compte.TypeDeCompte)
                        return false;
                }
            }

            ListeDeComptes.Add(compte);
            return true;
        }

        /// <summary>
        ///     Ajouter une transaction à la liste des transactions
        /// </summary>
        /// <param name="transaction"></param>
        public void AjouterTransaction(Transaction transaction)
        {
            ListeTransactions.Add(transaction);
        }

        /// <summary>
        ///     Fermer un compte 
        /// </summary>
        /// <param name="compte"></param>
        public void FermerCompte(Compte compte)
        {
            if (!compte.EstFermer())
            {
                compte.FermerCompte();
            }
        }

        /// <summary>
        ///     Permet d'éxecuter une transaction banquaire
        /// </summary>
        /// <param name="transaction"></param>
        public void ExecuterTransaction(Transaction transaction)
        {
            try
            {
                ValiderTransaction(transaction);
                Compte compte = TrouverCompte(transaction.NuméroClient, transaction.NuméroCompte);
                string typeTransansaction = transaction.TypeTransaction;
                double montant = 0;
                if (transaction is TransactionMonétaire)
                {
                    montant = (transaction as TransactionMonétaire).Montant;
                }

                 switch (typeTransansaction)
                    {
                        case "D":
                            compte.Déposer(montant);
                            break;
                        case "DGA":
                            compte.DéposerGuichetAutomatique(montant);
                            break;
                        case "R":
                            compte.Retirer(montant);
                            break;
                        case "RGA":
                            compte.RetirerGuichetAutomatique(montant);
                            break;
                        case "C":
                            compte.RetirerChèque(montant);
                            break;
                        case "VM":
                            (compte as CompteFlexible).VirementMarge(montant);
                            break;
                        case "I":
                            compte.RendreInactif();
                            break;
                        case "A":
                            compte.RendreActif();
                            break;
                        case "S":
                            compte.AfficherSolde();
                            break;
                        default:
                            break;
                    }
            }
            catch (Exception e)
            {
                ListeExceptions.Add(e);
            }
        }

        /// <summary>
        ///     Retourner le solde global d'un client
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <returns></returns>
        public double SoldeTotal(string numéroClient)
        {
            return TrouverLesComptes(numéroClient).Sum(c => c.SoldeCompte);
        }

        /// <summary>
        ///     Retourner un client en fonction de son numéro de client
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <returns> Retourne un Client </returns>
        public Client TrouverClient(string numéroClient)
        {
            return ListeDeClients.Find(client => client.NuméroClient == numéroClient);

        }

        /// <summary>
        ///     Retourner la liste des comptes pour un client à partir de son numéro
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <returns> Retourne une liste des comptes du client</returns>
        public List<Compte> TrouverLesComptes(string numéroClient)
        {
            return ListeDeComptes.FindAll(compte => compte.NuméroClients[0] == numéroClient || compte.NuméroClients[1] == numéroClient).ToList(); // Naviguer la liste de client?
        }

        /// <summary>
        ///     Retourne un compte à partir du numéro de client et de son numéro de compte
        /// </summary>
        /// <params>
        ///     <param name="numéroClient"></param>
        ///     <param name="numéroCompte"></param>
        /// </params>
        /// <returns> Retourne un compte </returns>
        public Compte TrouverCompte(string numéroClient, string numéroCompte)
        {
            return ListeDeComptes.Find(compte => compte.NuméroClients[0] == numéroClient || compte.NuméroClients[1] == numéroClient); // Naviguer la liste de client?
        }

        /// <summary>
        /// Valider quelques paramètres de transactions
        /// </summary>
        /// <param name="transaction"></param>
        public void ValiderTransaction(Transaction transaction)
        {
            if (!ListeDeClients.Select(c => c.NuméroClient).Contains(transaction.NuméroClient))
                throw new Exception();
            if (!ListeDeComptes.Select(c => c.NuméroCompte).Contains(transaction.NuméroCompte))
                throw new Exception();
            if (!((transaction as TransactionMonétaire).Montant > 0))
                throw new Exception();
            if (!listetypeTransaction.Contains(transaction.TypeTransaction))
                throw new Exception();
        }
        #endregion


    }
}