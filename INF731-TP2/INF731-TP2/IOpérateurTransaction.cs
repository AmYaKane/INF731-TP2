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
///         Interface définissant les Opérations de transaction
///     </summary>
/// </INF731-TP2>

namespace INF731_TP2
{
    interface IOpérateurTransaction
    {
        void ExecuterTransaction(Transaction transaction);
    }
}
