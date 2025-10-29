using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Exceptions;

namespace ThreadingBanking.Entities
{
    public class BankAccount
    {
        public readonly int AccountNumber;
        public double Balance;

        public BankAccount(int accountNumber, double balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0) throw new EmptyOrNegativeAmountException();
            this.Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (this.Balance - amount >= 0) Balance -= amount;
            else
            {
                throw new InsufficientFundsException($"Withdrawal impossible: You're missing {amount - this.Balance} € to complete the operation. You're poor lol");
            }
        }

        public void TransferTo(BankAccount destination, double amount)
        {
            if (amount <= 0) throw new EmptyOrNegativeAmountException();
            if (this.Balance - amount <= 0) throw new EmptyOrNegativeAmountException();

            this.Balance -= amount;
            destination.Balance += amount;
        }
    }
}
