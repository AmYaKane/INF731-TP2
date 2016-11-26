﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

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
        const string JOURNAL = "Journal - ";
        static string ligneTiret = new string('-', 70);
        static string ligneÉtoile = new string('*', 70);

        static readonly Dictionary<string, string> transactions = new Dictionary<string, string>
        {
            { "D", "Dépot au comptoir d'un montant de : {0}" },
            { "DGA", "Dépot au guichet d'un montant de : {0}" },
            { "R", "Retrait au comptoir d'un montant de : {0}" },
            { "RGA", "Retrait au guichet d'un montant de : {0}" },
            { "C", "Tirer un chéque d'un montant de : {0}" },
            { "VM", "Versement sur la marge d'un montant de : {0}" },
            { "I", "Rendre inactif le compte" },
            { "A", "Rendre actif le compte" },
            { "S", "Obtenir le solde" }
        };
        #endregion


        #region Déclaration des propriétés
        #endregion


        #region Déclaration des méthodes

        /// <summary>
        /// Lit une ligne csv et retourne les informations d'un client(numéroClient;Nom;Prénom)
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns></returns>
        private static string[] ParseCSV(string ligne)
        {
            string[] tableauÉléments = ligne.Split(SEPARATEUR);
            for (int i = 0; i < tableauÉléments.Length; ++i)
                tableauÉléments[i] = tableauÉléments[i].Trim();

            return tableauÉléments;
        }


        /// <summary>
        /// Lit un fichier et génère une liste de client 
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public static List<Client> loadClients(String cheminFichier)
        {
            string[] attributs;
            List<Client> listeClients = new List<Client>();

            foreach (var Ligne in File.ReadLines(cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                listeClients.Add(new ClientIndividuel(attributs[0], attributs[1], attributs[2]));
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

        /// <summary>
        /// Lit une ligne csv et retourne les informations d'un client 
        /// </summary>
        /// <param name="tableauDesÉléments"></param>
        /// <returns></returns>
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

        public static Object RetournerCompte(Compte compte)
        {
            Object value = "";
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(compte))
            {
                //string name = descriptor.Name;
              value = descriptor.GetValue(compte);
                //s += value; 
                Console.Write(value);
                Console.Write(SEPARATEUR);
            }
            return value;
        }

    /// <summary>
    /// Lit un fichier et génère une liste de compte 
    /// </summary>
    /// <param name="cheminFichier"></param>
    /// <returns></returns>
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


        /// <summary>
        /// Lire le fichier de transaction
        /// </summary>
        /// <param name="cheminFichier"></param>
        public static List<Transaction> ChargerTransactions(String cheminFichier)
        {
            string[] attributs;
            List<Transaction> listeTransactions = new List<Transaction>();

            foreach (var Ligne in File.ReadLines(CHEMIN + cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne); // LireLigne(Ligne);
                if (attributs.Length == 3)
                    listeTransactions.Add(new TransactionNonMonétaire(attributs[0].Trim(), attributs[1].Trim(), attributs[2].Trim()));
                else
                    listeTransactions.Add(new TransactionMonétaire(attributs[0].Trim(), attributs[1].Trim(), attributs[2].Trim(), double.Parse(attributs[3])));
            }

            return listeTransactions;
        }

        /// <summary>
        /// Ecrire le journal de transaction
        /// </summary>
        /// <param name="cheminFichier"></param>
        static void ÉcrireJournalTransaction(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

        /// <summary>
        /// Ecrire le journal de Client
        /// </summary>
        /// <param name="cheminFichier"></param>
        static void EcrireJournalClient(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

        /// <summary>
        /// Ecrire dans le journal de compte
        /// </summary>
        /// <param name="cheminFichier"></param>
        static void EcrireJournalCompte(String cheminFichier)
        {
            File.AppendAllText(cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }


        //public static IEnumerable<Transaction> GetBooks()
        //{
        //    List<Transaction> books = new List<Transaction>(ChargerTransactions(cheminFichier));
        //    return books;
        //}
        //static Dictionary<string, Compte> trouverLesComptes = new Dictionary<string, Compte>();
        //Dictionary<string, List<Compte>> rouverLesComptes = new Dictionary<string, List<Compte>>();
        //List<string> MyList = new List<string>();

        //public MyClass()
        //{
        //    MyList = new List<string>() { "1" };
        //    myD = new Dictionary<string, List<string>>()
        //{
        //  {"tab1", MyList }
        //};
        //}
        public static void ProduireJournalTransaction(Banque banque, string cheminFichier)
        {
            try
            {
                List<Transaction> list = new List<Transaction>(ChargerTransactions(cheminFichier));

                StreamWriter tw = new StreamWriter(CHEMIN + JOURNAL + cheminFichier);

                foreach (var s in list)
                {
                    try
                    {
                        //tw.WriteLine(s);
                        banque.ExecuterTransaction(s);
                        //tw.WriteLine();
                        tw.WriteLine(ligneTiret);
                        if (s is TransactionMonétaire)
                            tw.WriteLine(transactions[s.TypeTransaction], (s as TransactionMonétaire).Montant);
                        else
                            tw.WriteLine(transactions[s.TypeTransaction]); //s."Résultat aprés transaction"
                        tw.WriteLine(ligneTiret);
                        tw.WriteLine();
                        tw.WriteLine(banque.TrouverCompte(s.NuméroClient, s.NuméroCompte).FormatterCompte());
                        tw.WriteLine();
                    }
                    catch
                    {
                        tw.WriteLine(s);
                        tw.WriteLine("Erreur");
                    }

                }

                tw.WriteLine();
                foreach (Compte c in banque.ListeDeComptes)
                {
                    tw.WriteLine(c.NuméroClients[0] + " : " + c.NuméroCompte + " : " + c.SoldeCompte);
                    tw.WriteLine();

                }
                    

                tw.WriteLine();
                foreach (Compte compte in banque.ListeDeComptes)
                {
                    tw.WriteLine(compte.NuméroClients[0] + " : ");                
                    tw.Write(banque.SoldeTotal(compte.NuméroClients[0]));
                    tw.WriteLine();
                }
                    

                tw.Close();               
            }
            catch
            {


            }

        }


        public static string FormatterRésultatTransaction(Compte compte)
        {
            string unCompte = "";

            if (compte is CompteChèque)
                unCompte = compte.ToString();
            if (compte is CompteFlexible)
                unCompte = compte.ToString();
            if (compte is CompteÉpargne)
                unCompte = compte.ToString();

            return unCompte;
        }
        #endregion
    }
}
