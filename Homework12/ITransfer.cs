using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal interface ITransfer<T1, T2>
        where T1 : BankCheck
        where T2 : BankCheck
    {
        void Transfer (T1 t1, T2 t2, int _cash);
    }
}
