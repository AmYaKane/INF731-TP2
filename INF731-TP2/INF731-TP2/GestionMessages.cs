using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF731_TP2
{
    class GestionMessages
    {
        public static string MESSAGE_BIENVENUE = "Bienvenue dans l'application de la Banque Mandarine !";
        public static string MESSAGE_INVITE = "Pour sortir du programme, appuyez sur CTRL-C n'importe quand ou" + Environment.NewLine + "appuyez sur ENTER sans rien saisir d'autres lors de la saisit de nom de fichier.";
        public static string FICHIER_LISTE_CLIENT = "Donnez le nom du fichier contenant la liste de client à traiter : ";
        public static string FICHIER_LISTE_COMPTE = "Donnez le nom du fichier contenant la liste de compte à traiter : ";
        public static string FICHIER_LISTE_TRANSACTION = "Donnez le nom du fichier contenant la liste des transactions à traiter : ";
        public static string FICHIER_INEXISTANT = "! Le nom de fichier entré n'existe pas à l'endroit spécifié. Réessayez ! ";
        public static string NUMÉRO_CLIENT = "Numéro du client : ";
        public static string NUMÉRO_COMPTE = "Numéro de compte : ";
        public static string STATUT_COMPTE = "Statut du compte : ";
        public static string SOLDE_COMTE = "Solde du compte : ";
        public static string SOLDE_GLOBAL = "Solde global : ";
        public static string MONTANT_MARGE = "Marge de crédit : ";
        public static string SOLDE_MARGE = "Solde de la marge : ";
        public const char SÉPARATEUR = ';';
        public static string BILAN_COMPTE = "Bilan des comptes";
        public static string BILAN_CLIENT = "Bilan global des clients";
    }
}
