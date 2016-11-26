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

>>>>>>> 7e1d97f9201d5263933d2bc4d971e229e9b9f93e
namespace INF731_TP2
{
    public class TransactionMonétaire : Transaction
    {
        public double Montant { get; private set; }

        public TransactionMonétaire(string typeTransaction, string numéroClient, string numéroCompte, double montant)
            : base(typeTransaction, numéroClient, numéroCompte)
        {
            Montant = montant;
        }

<<<<<<< HEAD
        public override string ToString()
        {
            return  base.ToString() + ";" + Montant.ToString();
        }
=======
        public override Transaction Clone()
        {
            return new Transaction(this.TypeTransaction, this.NuméroClient, this.NuméroCompte);
        }

>>>>>>> 7e1d97f9201d5263933d2bc4d971e229e9b9f93e
        public override void Afficher()
        {
            Console.WriteLine(ToString());
        }

<<<<<<< HEAD
        public override Transaction Clone()
        {
            return new Transaction(this.TypeTransaction, this.NuméroClient, this.NuméroCompte);
=======
        public override string ToString()
        {
            return base.ToString() + ";" + Montant.ToString();
>>>>>>> 7e1d97f9201d5263933d2bc4d971e229e9b9f93e
        }
    }
}
