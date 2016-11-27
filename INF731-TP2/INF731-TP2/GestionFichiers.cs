using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

/// <INF731-TP2>
///     <auteurs>
///         <auteur> Olivier Contant <email> olivier.contant@USherbrooke.ca </email></auteur>
///         <auteur> Amadou Yaya Kane <email> Amadou.Yaya.Kane@USherbrooke.ca </email></auteur>
///         <auteur> Francoise Askoum Koumtingue <email> askoumk@gmail.com </email></auteur>
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
    public class listeClientsVide : ApplicationException { }
    public class listeComptesVide : ApplicationException { }
    public class TransactionLenghtInvalide : ApplicationException { }
    #endregion

    public static class GestionFichiers
    {
        #region Déclaration des attributs
        public const string CHEMIN = @"..\..\";
        public const string JOURNAL = "Journal - ";
        public const char SEPARATEUR = ';';
        public static string ligneTiret = new string('-', 70);
        public static string ligneÉtoile = new string('*', 70);
        public static string ligneExclamation = new string('!', 72);

        public const string CHÈQUE = "chèque";
        public const string FLEXIBLE = "flexible";
        public const string ÉPARGNE = "épargne";
        public const string CONJOINT = "conjoint";
        public const string INDIVIDUEL = "individuel";

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
        ///     Méthode qui permet de vérifier qu'un fichier existe 
        /// </summary>
        /// <param name="nomFichier"></param>
        /// <returns></returns>
        public static bool fichierExiste(string nomFichier)
        {
            bool fichierExiste = false;
            if (File.Exists(CHEMIN + nomFichier))
            {
                fichierExiste = true;
            }

            return fichierExiste;
        }

        /// <summary>
        ///     Lit une ligne csv et créer un Array de string
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns>
        ///     <return> client(numéroClient;Nom;Prénom) </return>
        ///     <return> compte() </return>
        /// </returns>
        private static string[] ParseCSV(string ligne)
        {          
            string[] tableauÉléments = ligne.Split(SEPARATEUR);
            for (int i = 0; i < tableauÉléments.Length; ++i)
                tableauÉléments[i] = tableauÉléments[i].Trim();

            return tableauÉléments;
        }
        
        /// <summary>
        ///     Lit un fichier et génère une liste de client 
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public static List<Client> ChargerClients(String cheminFichier)
        {
            string[] attributs;
            List<Client> listeClients = new List<Client>();

            foreach (var Ligne in File.ReadLines(CHEMIN + cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
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
        ///     Lit une ligne csv et retourne les informations d'un client 
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

            if (caractéristiqueDeCompte == CONJOINT)
            {
                numéroClients[1] = tableauDesÉléments[3];
                indice++;
            }

            switch (typeDeCompte)
            {
                case CHÈQUE:
                    numéroCompte = tableauDesÉléments[indice + 3];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 4].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 5]);

                    return new CompteChèque(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte);

                case ÉPARGNE:
                    numéroCompte = tableauDesÉléments[indice + 3];
                    statutCompte = char.Parse(tableauDesÉléments[indice + 4].ToUpper());
                    soldeCompte = double.Parse(tableauDesÉléments[indice + 5]);

                    return new CompteÉpargne(numéroClients, typeDeCompte, caractéristiqueDeCompte, numéroCompte, statutCompte, soldeCompte);

                case FLEXIBLE:
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
   
        /// <summary>
        ///     Lit un fichier et génère une liste de compte 
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public static List<Compte> ChargerComptes(String cheminFichier)
        {
            string[] attributs;
            List<Compte> listeComptes = new List<Compte>();

            foreach (var Ligne in File.ReadLines(CHEMIN + cheminFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
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
        ///     Lit fichier transaction et charge les transactions
        /// </summary>
        /// <param name="nomFichier"></param>
        /// <returns></returns>
        public static List<Transaction> ChargerTransactions(string nomFichier)
        {
            string[] attributs;
            List<Transaction> listeTransactions = new List<Transaction>();

            foreach (var Ligne in File.ReadLines(CHEMIN + nomFichier, Encoding.UTF7).Where(Ligne => Ligne != ""))
            {
                attributs = ParseCSV(Ligne);
                if (attributs.Length == 3)
                    listeTransactions.Add(new TransactionNonMonétaire(attributs[0], attributs[1], attributs[2]));
                else if (attributs.Length == 4)
                    listeTransactions.Add(new TransactionMonétaire(attributs[0], attributs[1], attributs[2], double.Parse(attributs[3])));
                else
                    throw new TransactionLenghtInvalide(); 
            }

            return listeTransactions;
        }
        
        /// <summary>
        /// Ecrire le journal de Client
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <param name="nomFichier"></param>
        static void EcrireJournalClient(String nomFichier)
        {
            File.AppendAllText(CHEMIN + nomFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

        /// <summary>
        /// Ecrire dans le journal de compte
        /// </summary>
        /// <param name="cheminFichier"></param>    
        /// <param name="nomFichier"></param>
        static void EcrireJournalCompte(String cheminFichier)
        {
            File.AppendAllText(CHEMIN + cheminFichier, "sometext");  // Write Text and close file (similar to Console.WriteLine on the logic)
            // TODO implement here
        }

        /// <summary>
        /// Produire le journal des transactions
        /// </summary>
        /// <param name="banque"></param>
        /// <param name="cheminFichier"></param>
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
                // TODO implement by AYK

            }

        }

        /// <summary>
        /// TODO implement by AYK 
        /// </summary>
        /// <param name="compte"></param>
        /// <returns></returns>
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
