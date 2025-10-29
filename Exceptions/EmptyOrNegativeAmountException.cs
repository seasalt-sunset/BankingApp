using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBanking.Exceptions
{
    public class EmptyOrNegativeAmountException : Exception
    {
        public EmptyOrNegativeAmountException(string message = "Invalid amount.") : base(message) { }
    }
}
