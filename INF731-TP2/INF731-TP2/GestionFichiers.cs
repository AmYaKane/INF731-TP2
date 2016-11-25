using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
namespace INF731_TP2
{
    #region // Déclaration des classes d'exception
    public class listeClientsVide : Exception { }
    public class listeComptesVide : Exception { }
    #endregion

    public static class GestionFichiers
    {
        #region Déclaration des attributs
        const string CHEMIN_SORTIE = "../../";
        const string CHEMIN = @"..\..\";
        const char SEPARATEUR = ';';
        #endregion


        #region Déclaration des propriétés
        #endregion


        #region Déclaration des méthodes

        /**
        * Description: Lit une ligne csv et retourne les informations d'un client 
        * @param: string ligne (numéroClient;Nom;Prénom)
        * @retour: string[]{numéroClient,Nom,Prénom}
        */
        private static string[] ParseCSV(string ligne)
        {
            string[] tableauÉléments = ligne.Split(SEPARATEUR);
            for (int i = 0; i < tableauÉléments.Length; ++i)
                tableauÉléments[i] = tableauÉléments[i].Trim();

            return tableauÉléments;
        }

        /**
        * Description: Lit un fichier et génère une liste de client 
        * @param: string cheminFichier (Fichier de clients)
        * @retour: Une liste de clients
        */
        public static List<Client> loadClients(string cheminFichier)
        {
            string[] attributs;
            List<Client> listeClients = new List<Client>();

            foreach (var Ligne in File.ReadLines(cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                listeClients.Add(new ClientIndividuel(attributs[0].Trim(), attributs[1].Trim(), attributs[2].Trim()));
            }

            if (listeClients.Count == 0)
            {
                throw new listeClientsVide();
            }
            else
            {
                return listeClients;
            }   
        }

        /**
        * Description: Lit une ligne csv et retourne les informations d'un client 
        * @param: string ligne  ()
        * @param: Banque        (Permet de référencer les objets, méthodes qui existent au niveau de Banque)
        * @retour: Compte       (Retourne un compte)
        */
        private static Compte CréerCompte(string[] tableauDesÉléments)
        {
            string[] numéroClients = new string[2];
            string typeDeCompte;
            string caractéristiqueDeCompte;
            string numéroCompte;
            char statutCompte;
            double soldeCompte;

            int indice = 0;

            numéroClients[0] = tableauDesÉléments[0];
            typeDeCompte = tableauDesÉléments[1].ToLower();
            caractéristiqueDeCompte = tableauDesÉléments[2].ToLower();

            if (caractéristiqueDeCompte == "conjoint")
            {
                numéroClients[1] = tableauDesÉléments[3];
                indice++;
            }

            switch (typeDeCompte)
            {
                case "chèque":
                    numéroCompte = tableauDesÉléments[indice + 3];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 4].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 5]);

                    return new CompteChèque(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte);

                case "épargne":
                    numéroCompte = tableauDesÉléments[indice + 3];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 4].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 5]);

                    return new CompteÉpargne(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte);

                case "flexible":
                    string modeFacturation = tableauDesÉléments[indice + 3].ToLower();
                    numéroCompte = tableauDesÉléments[indice + 4];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 5].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 6]);
                    double montantMarge = double.Parse(tableauDesÉléments[indice + 7]);
                    double soldeMarge = double.Parse(tableauDesÉléments[indice + 8]);

                    return new CompteFlexible(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte, modeFacturation, montantMarge, soldeMarge);

                default:
                    return new CompteChèque(new string[2] { "Default", "Default" }, "Default", "Default", "Default", 'E', 0);
            }
        }

        /**
        * Description: Lit un fichier et génère une liste de compte 
        * @param: string cheminFichier (Fichier de clients)
        * @retour: Une liste de comptes
        */
        public static List<Compte> loadComptes(String cheminFichier)
        {
            string[] attributs;
            List<Compte> listeComptes = new List<Compte>();

            foreach (var Ligne in File.ReadLines(cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                listeComptes.Add(CréerCompte(attributs));
            }

            if (listeComptes.Count == 0)
            {
                throw new listeComptesVide();
            }
            else
            {
                return listeComptes;
            }
        }


        /**
         * 
         */
        public static List<Transaction> ChargerTransactions(string nomFichier)
        {
            string[] attributs;
            List<Transaction> listeTransactions = new List<Transaction>();

            foreach (var Ligne in File.ReadLines(CHEMIN + nomFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne); // LireLigne(Ligne);
                if (attributs.Length == 3)
                    listeTransactions.Add(new TransactionNonMonétaire(attributs[0].Trim(), attributs[1].Trim(), attributs[2].Trim()));
                else
                    listeTransactions.Add(new TransactionMonétaire(attributs[0].Trim(), attributs[1].Trim(), attributs[2].Trim(), double.Parse(attributs[3])));
            }

            return listeTransactions;
        }

        /**
         * 
         */
        static void ÉcrireJournalTransaction(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

        /**
         * 
         */
        static void EcrireJournalClient(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

        /**
         * 
         */
        static void EcrireJournalCompte(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }
        #endregion
    }
}