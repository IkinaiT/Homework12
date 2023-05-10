using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class Transferer : ITransfer
    {
        public virtual void Transfer<T>(T t1, T t2, float cash) where T : BankCheck
        {
            
        }
    }
}
