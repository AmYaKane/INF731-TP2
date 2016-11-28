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
        static void AfficherBienvenue()
        {
            Console.WriteLine(GestionFichiers.ligneÉtoile);
            Console.WriteLine();
            Console.WriteLine(GestionMessages.MESSAGE_BIENVENUE);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(GestionMessages.MESSAGE_INVITE);
            Console.WriteLine();
            Console.WriteLine(GestionFichiers.ligneÉtoile);
            Console.WriteLine();
        }
        static void AfficherTitre (string text)
        {
            Console.WriteLine();
            Console.WriteLine(GestionFichiers.ligneÉtoile);
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine(GestionFichiers.ligneÉtoile);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void AfficherSousTitre(string text)
        {
            Console.WriteLine();
            Console.WriteLine(GestionFichiers.ligneTiret);
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine(GestionFichiers.ligneTiret);
            Console.WriteLine();
        }

        static void AfficherErreur (string text)
        {
            Console.WriteLine();
            Console.WriteLine(GestionFichiers.ligneExclamation);
            Console.WriteLine();
            Console.WriteLine(GestionMessages.FICHIER_INEXISTANT);
            Console.WriteLine();
            Console.WriteLine(GestionFichiers.ligneExclamation);
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // Génération de la banque avec des comptes et clients
            Banque Mandarine = new Banque("Mandarine");

            AfficherBienvenue();
            
            // -------------------------------------------
            // Chargement de la liste des clients
            // -------------------------------------------

            AfficherTitre("Liste des clients.");

            // Saisi du fichier de clients
            Console.Write(GestionMessages.FICHIER_LISTE_CLIENT);
            string fichierClients = Console.ReadLine();
            if (String.IsNullOrEmpty(fichierClients))
                Environment.Exit(0);

            while ( !GestionFichiers.fichierExiste(fichierClients) )
            {
                // Le fichier n'existe pas, demande à l'utilisateur d'entrer un fichier valide. 
                AfficherErreur(GestionMessages.FICHIER_INEXISTANT);

                Console.Write(GestionMessages.FICHIER_LISTE_CLIENT);
                fichierClients = Console.ReadLine();
                if (String.IsNullOrEmpty(fichierClients))
                    Environment.Exit(0);
            }

            AfficherSousTitre("Chargement des clients");
            foreach (ClientIndividuel client in (GestionFichiers.ChargerClients(fichierClients)))
            {
                if (Mandarine.AjouterClient(client))
                    Console.WriteLine("Client {0} Ajouté", client);
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR: Client {0} existe déjà", client);
                    Console.WriteLine();
                }
            }

<<<<<<< HEAD


            // -------------------------------------------
            // Chargement de la liste de comptes
            // -------------------------------------------

            AfficherTitre("Liste des comptes.");

            // Saisi du fichier de comptes
            Console.Write(GestionMessages.FICHIER_LISTE_COMPTE);
            string fichierComptes = Console.ReadLine();
            if (String.IsNullOrEmpty(fichierClients))
                Environment.Exit(0);

            while (!GestionFichiers.fichierExiste(fichierComptes))
            {
                // Le fichier n'existe pas, demande à l'utilisateur d'entrer un fichier valide.
                AfficherErreur(GestionMessages.FICHIER_INEXISTANT);

                Console.Write(GestionMessages.FICHIER_LISTE_COMPTE);
                fichierComptes = Console.ReadLine();
                if (String.IsNullOrEmpty(fichierClients))
                    Environment.Exit(0);
=======
            Console.WriteLine();
            Console.WriteLine("Liste des comptes");
            Console.WriteLine();
           
            string FichierComptes = "ListeDeComptes.txt";
            foreach (Compte compte in (GestionFichiers.loadComptes(FichierComptes)))
                if (Tangerine.AjouterCompte(compte))
                    Console.WriteLine("Compte {0} Ajouté", compte);
                else
                    Console.WriteLine("ERREUR: Compte {0} existe déjà", compte);

            foreach (Compte c in Tangerine.ListeDeComptes)
            {
                //c.Afficher();
                //c.Déposer(100000);
                //Console.WriteLine("Solde Apres le depot de 500: ");
               // c.Afficher();
>>>>>>> e7f93f33f6840b3db8458da4610c4ddd215026c9
            }

            AfficherSousTitre("Chargement des comptes");
            foreach (Compte compte in (GestionFichiers.ChargerComptes(fichierComptes)))  // !!! swith case per TypeCompte
                if (Mandarine.AjouterCompte(compte))
                {
                    Console.WriteLine("Compte {0} Ajouté", compte.NuméroCompte);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR: Le client {0}, possède déjà un compte {1} de type {2}", compte.NuméroClients[0], compte.CaractéristiqueDeCompte, compte.TypeDeCompte);
                    Console.WriteLine();
                }

<<<<<<< HEAD

            // -------------------------------------------
            // Chargement de la liste de transactions
            // -------------------------------------------
            AfficherTitre("Liste des transactions");

            // Saisi du fichier de transaction
            Console.Write(GestionMessages.FICHIER_LISTE_TRANSACTION);
            string fichierTransactions = Console.ReadLine();
            
            while (!GestionFichiers.fichierExiste(fichierTransactions))
            {
                // Le fichier n'existe pas, demande à l'utilisateur d'entrer un fichier valide.
                AfficherErreur(GestionMessages.FICHIER_INEXISTANT);
                
                Console.Write(GestionMessages.FICHIER_LISTE_CLIENT);
                fichierTransactions = Console.ReadLine();
                if (String.IsNullOrEmpty(fichierClients))
                    Environment.Exit(0);
            }
=======
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
>>>>>>> e7f93f33f6840b3db8458da4610c4ddd215026c9

            AfficherSousTitre("Chargement des transactions");
            foreach (Transaction transaction in (GestionFichiers.ChargerTransactions(fichierTransactions)))
                Mandarine.AjouterTransaction(transaction);

            foreach (Transaction transaction in Mandarine.ListeTransactions)
            {
                transaction.Afficher();
                Mandarine.ExecuterTransaction(transaction); // ListeDeClients.txt   ListeDeComptes.txt   Janvier.txt  fichierTestCompte.txt
                GestionFichiers.ProduireJournalTransaction(Mandarine, fichierTransactions);
            }

            GestionFichiers.ProduireListeDesExceptions(Mandarine);
        }
    }
}
