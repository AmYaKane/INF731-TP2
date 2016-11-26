using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF731_TP2
{
    interface IOpérateurTransaction
    {
        void ExecuterTransaction(Transaction transaction);
    }
}
