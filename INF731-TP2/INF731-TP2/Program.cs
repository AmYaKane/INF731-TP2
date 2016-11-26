using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF731_TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            // À noter que nos lectures de fichiers ne prennents pas les décimales en compte (à investiguer)

            // Génération de la banque avec des comptes et clients
            Banque Tangerine = new Banque("Tangerine");

            Console.WriteLine("Liste des clients");
            Console.WriteLine();
            string FichierClient = "../../ListeDeClients.txt";
            foreach (Client client in (GestionFichiers.loadClients(FichierClient)))
                Tangerine.AjouterClient(client);
            foreach (Client c in Tangerine.ListeDeClients)
            {
                c.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine("Liste des comptes");
            Console.WriteLine();
            //string FichierComptes = "../../ListeDeComptes.txt";
            string FichierComptes = "../../fichierTestCompte.txt";
            foreach (Compte compte in (GestionFichiers.loadComptes(FichierComptes)))
                Tangerine.AjouterCompte(compte);
            foreach (Compte c in Tangerine.ListeDeComptes)
            {
     
            }

            Console.WriteLine();
            Console.WriteLine("Liste des Transactions");
            Console.WriteLine();

            string FichierTransaction = "Transactions.txt";
            foreach (Transaction transaction in (GestionFichiers.ChargerTransactions(FichierTransaction)))
                Tangerine.AjouterTransaction(transaction);
            foreach (Transaction transaction in Tangerine.ListeTransactions)
            {
                transaction.Afficher();
                Tangerine.ExecuterTransaction(transaction);
                //Tangerine.TrouverCompte(transaction.NuméroClient, transaction.NuméroCompte).Afficher();
            }

            GestionFichiers.ProduireJournalTransaction(Tangerine,FichierTransaction);
            Console.WriteLine();
            Console.WriteLine("Résultats après Transactions");
            Console.WriteLine();

            
            //foreach (Client c in Tangerine.ListeDeClients)
            //{
            //    //c.
            //    Console.WriteLine(Tangerine.SoldeTotal((c as ClientIndividuel).NuméroClient));
            //    foreach (var v in Tangerine.TrouverLesComptes(c.NuméroClient))
            //        Console.WriteLine(v.ToString());
            //}
            //Tangerine.ListeDeClients.FindAll(c => c.NuméroClient)
            //Tangerine.ExecuterTransaction()
            // GestionTransactions.EffectuerTransaction(Tangerine);
            //// Test Exception CompteTypeInvalide
            //string[] numeroclient = { "123", "123" };
            //Compte testCompte = new CompteChèque(numeroclient, "something","individuel","123456",'A',300.00);


            //// Test des méthodes de class
            //CompteChèque.Retirer(200);
        }
    }
}
