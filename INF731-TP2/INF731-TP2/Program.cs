using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <INF731-TP2>
///     <date_remise> 2016-11-29 </date_remise>
/// 
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
///         <auteur> Amadou Yaya Kane <email> Amadou.Yaya.Kane@USherbrooke.ca </email></auteur>
///         <auteur> Francoise Askoum Koumtingue <email> askoumk@gmail.com </email></auteur>
///         <auteur> Bassir Diallo <email> albassir02@gmail.com </email></auteur>
///         <auteur> Sory DIANE <email> sorydian2@gmail.com </email></auteur>
///     </auteurs>
///     
///     <summary>
///         Créer une application de traitement d'opérations bancaires en utilisant les principes de programmation orienté objet.
///             - Créer la Banque Mandarine
///                 - Créer des clients de la banque
///                 - Créer des comptes bancaires avec les contraintes d'affaire énoncées
///                 - Créer des transactions sur ces comptes par des clients
///             - Effectuer des transactions mensuelles
///                 - Écrire un Journal des transactions
///                 - Écrire un rapport sur le statut des comptes
///             - Terminer l'application
///                 - Créer une sauvegarde des clients
///                 - Créer une sauvegarde des comptes 
///     </summary>
///     
///     <Fichiers>
///         <Entré> ../../ListeDeClients.txt </Entré>
///         <Entré> ../../ListeDeComptes.txt </Entré>
///         <Entré> ../../[mois].txt </Entré>
///         
///         <Sorti> ../../ListeDeClients-[mois].txt </Sorti>
///         <Sorti> ../../ListeDeComptes-[mois].txt </Sorti>
///         <Sorti> ../../Journal-[mois].txt </Sorti>
///         
///         <Source> Banque.cs </Source>
///         <Source> Client.cs </Source>
///         <Source> ClientIndividuel.cs </Source>
///         <Source> Compte.cs </Source>
///         <Source> CompteChèque.cs </Source>
///         <Source> CompteÉpargne.cs </Source>
///         <Source> CompteFlexible.cs </Source>
///         <Source> Transaction.cs </Source>
///         <Source> TransactionMonétaire.cs </Source>
///         <Source> TransactionNonMonétaire.cs </Source>
///         <Source> GestionTransactions.cs </Source>
///         <Source> GestionFichiers.cs </Source>
///         <Source> ICalculateurIntérêts.cs </Source> 
///     </Fichiers>
/// </INF731-TP2>

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
            string FichierClient = "ListeDeClients.txt";
            foreach (Client client in (GestionFichiers.ChargerClients(FichierClient)))
                if (Tangerine.AjouterClient(client))
                    Console.WriteLine("Client {0} Ajouté", client);
                else
                    Console.WriteLine("ERREUR: Client {0} existe déjà", client);
            foreach (Client c in Tangerine.ListeDeClients)
            {
                c.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine("Liste des comptes");
            Console.WriteLine();
           
            string FichierComptes = "ListeDeComptes.txt";
            foreach (Compte compte in (GestionFichiers.ChargerComptes(FichierComptes)))
                if (Tangerine.AjouterCompte(compte))
                    Console.WriteLine("Compte {0} Ajouté", compte);
                else
                    Console.WriteLine("ERREUR: Compte {0} existe déjà", compte);

            foreach (Compte c in Tangerine.ListeDeComptes)
            {
                //c.Afficher();
                //c.Déposer(100000);
                //Console.WriteLine("Solde Apres le depot de 500: ");
                c.Afficher();
            }

            //Console.WriteLine();
            //Console.WriteLine("Liste des Transactions");
            //Console.WriteLine();

            string FichierTransaction = "Transactions.txt";
            foreach (Transaction transaction in (GestionFichiers.ChargerTransactions(FichierTransaction)))
                Tangerine.AjouterTransaction(transaction);
            foreach (Transaction transaction in Tangerine.ListeTransactions)
            {
                transaction.Afficher();
                Tangerine.ExecuterTransaction(transaction);
                //Tangerine.TrouverCompte(transaction.NuméroClient, transaction.NuméroCompte).Afficher();
            }
            //string FichierTransaction = "ListeDeTransactions.txt";
            //foreach (Transaction transaction in (GestionFichiers.ChargerTransactions(FichierTransaction)))
            //    Tangerine.AjouterTransaction(transaction);
            //foreach (Transaction transaction in Tangerine.ListeTransactions)
            //{
            //    transaction.Afficher();
            //}

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
           // }

            Console.WriteLine();
            Console.WriteLine("Résultats après Transactions");
            Console.WriteLine();
            //GestionTransactions.EffectuerTransaction(Tangerine);
            //// Test Exception CompteTypeInvalide
            //string[] numeroclient = { "123", "123" };
            //Compte testCompte = new CompteChèque(numeroclient, "something","individuel","123456",'A',300.00);


            //// Test des méthodes de class
            //CompteChèque.Retirer(200);
        }
    }
}
