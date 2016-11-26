using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Amadou Yaya Kane <email> Amadou.Yaya.Kane@USherbrooke.ca </email></auteur>
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

namespace INF731_TP2
{
    class GestionTransactions
    {
       
       
        //public static void EffectuerTransaction(Banque banque)
        //{
        //    //List<Transaction> transactionsEffectuées = new List<Transaction>();
        //    foreach (var transaction in banque.ListeTransactions)
        //    {
        //        try
        //        {
        //            var typeTransaction = transaction.TypeTransaction;
        //            //Client client = banque.TrouverClient(transaction.NuméroClient);
        //            Compte compte = banque.TrouverCompte(transaction.NuméroClient, transaction.NuméroCompte);
        //            //compte.Afficher();
        //            //double montant = 0;
        //            double montant = 0; // (transaction as TransactionMonétaire).Montant;
        //            if (transaction is TransactionMonétaire)
        //            {
        //                montant = (transaction as TransactionMonétaire).Montant;
        //            }
        //            // double solde;

        //            switch (typeTransaction)
        //            {
        //                case "D":
        //                    compte.Déposer(montant);
        //                    //compte.Afficher(); // Test 
        //                    //ListeSoldeTransaction.Add(new TransactionOpération(typeTransaction, client.NuméroClient, compte.NumeroDeCompte, compte.SoldeCompte));
        //                    break;
        //                case "DGA":
        //                    compte.Déposer(montant);
        //                    //compte.Afficher(); // Test 
        //                    break;
        //                case "R":
        //                    compte.RetirerComptoir(montant);
        //                    //compte.Afficher(); // Test 
        //                    break;
        //                case "RGA":
        //                    compte.RetirerGuichetAutomatique(montant);
        //                    //compte.Afficher(); // Test 
        //                    break;
        //                case "C":
        //                    compte.RetirerChèque(montant);
        //                    //compte.Afficher(); // Test 
        //                    // je ne trouve pas cette méthode ???
        //                    break;
        //                case "VM":
        //                    //compte.Afficher();
        //                    //compte.VirementMarge(montant);
        //                    // Je ne trouve pas cette méthode ???
        //                    break;
        //                case "I":
        //                    compte.RendreInactif();
        //                    //compte.Afficher(); // Test 
        //                    break;
        //                case "A":
        //                    compte.RendreActif();
        //                    //compte.Afficher(); // Test 
        //                    break;
        //                case "S":
        //                    // compte.AfficherSolde();
        //                    //compte.Afficher(); // Test 
        //                    break;
        //                default:
        //                    break;

        //            }
        //        }

        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //        }
        //    }

        //}
    }
}
