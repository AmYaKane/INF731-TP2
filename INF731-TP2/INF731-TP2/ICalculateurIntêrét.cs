using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
=======
/// <INF731-TP2>
///     <auteurs>
///         <auteur> Amadou Yaya Kane <email> Amadou.Yaya.Kane@USherbrooke.ca </email></auteur>
///     </auteurs>
/// 
///     <summary>
///         Classe Interface contrôlant la gestion du calcul des intérêts reliés à un compte.   
///     </summary>
///     
///      <méthodes>
///         <méthode> 
///             <Nom> CalculerIntérêts() </Nom>
///             <Description> Méthode pour calculer les intérêts sur le solde du compte. </Description>
///         </méthode>
///         <méthode>
///             <Nom> AjouterIntérêts() </Nom>
///             <Description> Méthode pour ajouter les intérêts calculés au solde du compte. </Description>
///         </méthode>

>>>>>>> 7e1d97f9201d5263933d2bc4d971e229e9b9f93e
namespace INF731_TP2
{
    interface ICalculateurIntêrét
    {
<<<<<<< HEAD
        double CalculerIntérêt();
=======
        /// <summary>
        /// Méthode pour calculer les intérêts sur le solde du compte.
        /// </summary>
        /// <returns></returns>
        double CalculerIntérêts();

        /// <summary>
        /// Méthode pour ajouter les intérêts calculés au solde du compte.
        /// </summary>
        /// <returns></returns>
        bool AjouterIntérêts();
>>>>>>> 7e1d97f9201d5263933d2bc4d971e229e9b9f93e
    }
}
