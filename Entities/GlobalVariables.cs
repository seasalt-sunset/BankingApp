using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBanking.Entities
{
    public static class GlobalVariables
    {
        public static int accountId;

        public static int GenerateNewId()
        {
            int newId = accountId;
            accountId++;
            return newId;

        }
    }
}
