using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBanking.Exceptions
{
    public class NullAccountException : Exception
    {
        public NullAccountException(string message = "The account you're looking for doesn't exist.") : base(message) { }
    }
}
