using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBanking.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message = "Insufficient funds!!!") : base(message) { }
    }
}
