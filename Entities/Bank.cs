using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Exceptions;

namespace ThreadingBanking.Entities
{
    public class Bank
    {
        public List<BankAccount> accounts = new List<BankAccount>();

        public BankAccount OpenAccount(double initialBalance)
        {
            if (initialBalance < 0) throw new EmptyOrNegativeAmountException("Invalid starting balance");

            BankAccount newAccount = new BankAccount(GlobalVariables.GenerateNewId(), initialBalance);
            this.accounts.Add(newAccount);

            return newAccount;
        }

        public BankAccount? FindAccount(int accountNumber)
        {
            foreach (var account in this.accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public void CloseAccount(int accountNumber)
        {
            BankAccount? account = FindAccount(accountNumber);
            if(account != null)
            {
                accounts.Remove(account);
                Console.WriteLine("Account closed!");
                return;
            }

            Console.WriteLine("Account not found!");
        }

        public double GetTotalBalance()
        {
            double sumBalance = 0;

            foreach(var account in this.accounts)
            {
                sumBalance += account.Balance;
            }

            return sumBalance;
        }

        public void Transfer(int sourceAccountNumber, int destinationAccountNumber, double amount)
        {
            BankAccount? sourceAccount = FindAccount(sourceAccountNumber);
            BankAccount? destinationAccount = FindAccount(destinationAccountNumber);
            if(sourceAccount == null || destinationAccount == null)
            {
                throw new NullAccountException();
            }

            sourceAccount.TransferTo(destinationAccount, amount);
        }

        public double GetAccountBalance(int accountNumber)
        {
            BankAccount account = FindAccount(accountNumber);
            if (account == null) throw new NullAccountException();

            return account.Balance;
        }
    }
}
