using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Entities;

namespace ThreadingBanking.Helpers
{
    public static class HELL
    {
        public static void DepositCompleted(int accountNumber, int amount)
        {
            Console.WriteLine($"Deposit of {amount}€ to account no. {accountNumber} completed.");
        }

        public static void WithdrawalCompleted(int accountNumber, int amount)
        {
            Console.WriteLine($"Withdrawal of {amount}€ to account no. {accountNumber} completed.");
        }

        public static void TransferCompleted(int accountNumber1, int accountNumber2, int amount)
        {
            Console.WriteLine($"Transfer of {amount}€ from account no. {accountNumber1} to account no. {accountNumber2} completed.");
        }

        public static void AccountOpened(int initialBalance)
        {
            Console.WriteLine($"Account opened! Initial balance: {initialBalance}");
        }
    }
}
