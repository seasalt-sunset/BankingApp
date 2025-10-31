using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Entities;

namespace ThreadingBanking.Operations;

public class Actions
{
    public static bool HellActivated { get; set; } = false;
    public static void Deposit(Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
                BankAccount account = GetRandomAccount(bank, random);
                int amount = random.Next(999999);
                account.Deposit(amount);
                if (HellActivated) Helpers.HELL.DepositCompleted(account.AccountNumber, amount);
            }
        }

    }

    public static void Withdraw(Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
                BankAccount account = GetRandomAccountNotEmpty(bank, random);
                int amount = (int) account.Balance;
                if(amount >= 1)
                {
                account.Withdraw(random.Next(1, amount));
                if (HellActivated) Helpers.HELL.WithdrawalCompleted(account.AccountNumber, amount);
                }
            }
        }
    }

    public static void Transfer(Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
                BankAccount account1 = GetRandomAccountNotEmpty(bank, random);
                BankAccount account2 = GetRandomAccount(bank, random, account1.AccountNumber);
                int balance = (int) account1.Balance;
                if(balance >= 1)
                {
                int amount = random.Next(1, balance);
                account1.TransferTo(account2, amount);
                if (HellActivated) Helpers.HELL.TransferCompleted(account1.AccountNumber, account2.AccountNumber, amount);
                }

            }
        }

    }

    public static void Open(Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
                int initialBalance = random.Next(999999);
                bank.OpenAccount(initialBalance);
                if (HellActivated) Helpers.HELL.AccountOpened(initialBalance);

            }
        }

    }

    public static void ActivateHELL(Bank bank)
    {
        if (!HellActivated) HellActivated = true;
        else HellActivated = false;
    }

    public static BankAccount GetRandomAccount(Bank bank, Random random, int excludeId = -1)
    {
        bool success = false;
        BankAccount? account = null;
        while (!success)
        {
            account = bank.FindAccount(random.Next(GlobalVariables.accountId));
            if (account is not null)
            {
                if (account.AccountNumber != excludeId) success = true;
                else continue;
            }
            else Console.WriteLine("Account not found");
        }
        return account;
    }
    public static BankAccount GetRandomAccountNotEmpty(Bank bank, Random random)
    {
        BankAccount? account = null;
        while (true)
        {
            account = bank.FindAccount(random.Next(GlobalVariables.accountId));
            if (account is not null && account.Balance > 0) break;
        }
        return account;
    }
}
