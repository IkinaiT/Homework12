using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal interface ITransfer
    {
        void TopUp(float cash);
        bool Withdraw(float cash);
        void Transfer<T>(T t1, T t2, float cash);
    }
}
