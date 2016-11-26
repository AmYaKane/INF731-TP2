
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    public class Banque : IOpérateurTransaction
    {
        #region // Déclaration des attributs

        private string nomBanque;
        public List<Client> ListeDeClients { get; set; } // Propriété automatique
        public List<Compte> ListeDeComptes { get; set; } // Propriété automatique
        public List<Transaction> ListeTransactions { get; set; } // Propriété automatique
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
        /// Declaration du constructeur parametrique
        /// </summary>
        /// <param name="nomBanque"></param>
        public Banque(string nomBanque)
        {
            NomBanque = nomBanque;
            ListeDeClients = new List<Client>();
            ListeDeComptes = new List<Compte>();
            ListeTransactions = new List<Transaction>();
        }

        #endregion


        #region // Déclaration des méthodes

        /// <summary>
        /// Ajouter un client dans la liste des clients
        /// </summary>
        /// <param name="client"></param>
        public void AjouterClient(Client client)
        {
            ListeDeClients.Add(client);
        }

        public void AjouterCompte(Compte compte)
        {
            ListeDeComptes.Add(compte);
        }

        /// <summary>
        /// Ajouter une transaction à la liste des transactions
        /// </summary>
        /// <param name="transaction"></param>
        public void AjouterTransaction(Transaction transaction)
        {
            ListeTransactions.Add(transaction);
        }

        /// <summary>
        /// Fermer un compte 
        /// </summary>
        /// <param name="compte"></param>
        //public void FermerCompte(Compte compte)
        //{
        //    if (!compte.EstFermer())
        //    {
        //        compte.FermerCompte();
        //    }      
        //}



        /// <summary>
        /// Retourner un client en fonction de son numéro de client
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <returns></returns>
        public Client TrouverClient(string numéroClient)
        {
            return ListeDeClients.Find(client => client.NuméroClient == numéroClient);

        }

        /// <summary>
        /// Retourner la liste des comptes pour un client
        /// </summary>
        /// <param name="clientreçus"></param>
        /// <returns></returns>
        //public List<Compte> TrouverLesComptes(Client clientreçus)
        //{
        //    return ListeDeComptes.FindAll(compte => compte.NuméroClients[0] == clientreçus.NuméroClient || compte.NuméroClients[1] == clientreçus.NuméroClient).ToList();
        //}

        /// <summary>
        /// Retourner la liste des comptes pour un client à partir de son numéro
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <returns></returns>
        public List<Compte> TrouverLesComptes(string numéroClient)
        {
            return ListeDeComptes.FindAll(compte => compte.NuméroClients[0] == numéroClient || compte.NuméroClients[1] == numéroClient); // Naviguer la liste de client?
        }
      
        /// <summary>
        /// Retourne un compte à partir de son numéro
        /// </summary>
        /// <param name="numéroCompte"></param>
        /// <returns></returns>
        //public Compte TrouverCompte(string numéroCompte)
        //{
        //    return ListeDeComptes.Find(compte => compte.NuméroCompte == numéroCompte);

        //}

        /// <summary>
        /// Retourne un compte à partir du numéro de client et de son numéro
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <param name="numéroCompte"></param>
        /// <returns></returns>
        public Compte TrouverCompte(string numéroClient, string numéroCompte)
        {
            return ListeDeComptes.Find(compte => (compte.NuméroClients[0] == numéroClient || compte.NuméroClients[1] == numéroClient) && compte.NuméroCompte == numéroCompte);

        }

        /// <summary>
        /// Permet d'éxecuter une transaction banquaire
        /// </summary>
        /// <param name="transaction"></param>
        public void ExecuterTransaction(Transaction transaction)
        {
            Compte compte = TrouverCompte(transaction.NuméroClient, transaction.NuméroCompte);
            string typeTransansaction = transaction.TypeTransaction;
            double montant = 0; // (transaction as TransactionMonétaire).Montant;
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
                    compte.Déposer(montant);
                    break;
                case "R":
                    compte.RetirerComptoir(montant);
                    break;
                case "RGA":
                    compte.RetirerGuichetAutomatique(montant);
                    break;
                case "C":
                    compte.RetirerChèque(montant);
                    break;
                case "VM":
                    //compte.Afficher();
                    break;
                case "I":
                    compte.RendreInactif();
                    break;
                case "A":
                    compte.RendreActif();
                    break;
                case "S":
                    compte.AfficherSolde();
                   // compte.Afficher(); // Test 
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Retourner le solde global d'un client
        /// </summary>
        /// <param name="numéroClient"></param>
        /// <returns></returns>
        public double SoldeTotal(string numéroClient)
        {
            return TrouverLesComptes(numéroClient).Sum(c => c.SoldeCompte);
        }
        #endregion
    }
}