using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class Transactions<T1, T2> : ITransfer<T1, T2>
        where T1 : BankCheck
        where T2 : BankCheck
    {

        public void Transfer(T1 t1, T2 t2, int _cash)
        {
            BankCheck ch1, ch2;
            ch1 = t1;
            ch2 = t2;
            if (ch1.Withdraw(_cash))
            {
                ch2.TopUp(_cash);
            }
        }
    }
}
