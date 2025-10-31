using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Entities;

namespace ThreadingBanking.Helpers
{
    public static class ThreadManager
    {
        public static Thread DepositThread(Bank bank, object lockObject)
        {
            return new Thread(ThreadStartManager.DepositThreadStart(bank, lockObject));
        }

        public static Thread WithdrawThread(Bank bank, object lockObject)
        {
            return new Thread(ThreadStartManager.WithdrawThreadStart(bank, lockObject));
        }

        public static Thread TransferThread(Bank bank, object lockObject)
        {
            return new Thread(ThreadStartManager.TransferThreadStart(bank, lockObject));
        }

        public static Thread OpenThread(Bank bank, object lockObject)
        {
            return new Thread(ThreadStartManager.OpenThreadStart(bank, lockObject));
        }

        public static Thread HELLThread(Bank bank, object lockObject)
        {
            return new Thread(ThreadStartManager.HELLThreadStart(bank, lockObject));
        }

        public static bool IsNotNullAndAlive(Thread thread)
        {
            if (thread != null && thread.IsAlive) return true;
            
            return false;
        }
    }
}
