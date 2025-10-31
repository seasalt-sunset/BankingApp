using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Entities;

namespace ThreadingBanking.Helpers
{
    public class ThreadStartManager
    {
        public static ThreadStart DepositThreadStart(Bank bank, object lockObject)
        {
            return () => { Operations.Actions.Deposit(bank, lockObject); };
        }

        public static ThreadStart WithdrawThreadStart(Bank bank, object lockObject)
        {
            return () => { Operations.Actions.Withdraw(bank, lockObject); };
        }

        public static ThreadStart TransferThreadStart(Bank bank, object lockObject)
        {
            return () => { Operations.Actions.Transfer(bank, lockObject); };
        }

        public static ThreadStart OpenThreadStart(Bank bank, object lockObject)
        {
            return () => { Operations.Actions.Open(bank, lockObject); };
        }

        public static ThreadStart HELLThreadStart(Bank bank)
        {
            return () => { Operations.Actions.ActivateHELL(bank); };
        }
    }
}
