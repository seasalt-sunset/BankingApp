using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Entities;

namespace ThreadingBanking.Operations;

public class Actions
{
    public static void Deposit (Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while(stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
                BankAccount account = GetRandomAccount(bank, random);
                account.Deposit(random.NextInt64());
            }
        }

    }

    public static void Withdraw (Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
            BankAccount account = GetRandomAccount(bank, random);
            account.Withdraw(random.NextInt64((int) account.Balance));
            }
        }
    }

    public static void Transfer (Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
            BankAccount account1 = GetRandomAccount(bank, random);
            BankAccount account2 = GetRandomAccount(bank, random, account1.AccountNumber);
            account1.TransferTo(account2, random.NextInt64((long)account1.Balance));
            }
        }

    }

    public static void Open (Bank bank, object lockObject)
    {
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= 60000)
        {
            lock (lockObject)
            {
                bank.OpenAccount(random.NextInt64());
            }
        }

    }

    public static void HELL(Bank bank, object lockObject)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    public static BankAccount GetRandomAccount(Bank bank, Random random, int excludeId = -1)
    {
        bool success = false;
        BankAccount? account = null;
        while (!success)
        {
            account = bank.FindAccount((int)random.NextInt64(GlobalVariables.accountId));
            if (account is not null)
            {
                if (account.AccountNumber != excludeId) success = true;
                else continue;
            }
            else Console.WriteLine("Account not found");
        }
        return account;
    }
}
