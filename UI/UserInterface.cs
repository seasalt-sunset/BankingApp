using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingBanking.Entities;
using ThreadingBanking.Helpers;

namespace ThreadingBanking.UI
{
    public class UserInterface
    {
        public readonly object lockObject = new object();
        public async Task start()
        {
            Bank bank = new Bank();
            Thread depositThread = ThreadManager.DepositThread(bank, this.lockObject); 
            Thread withdrawThread = ThreadManager.WithdrawThread(bank, this.lockObject);
            Thread transferThread = ThreadManager.TransferThread(bank, this.lockObject);
            Thread openAccountThread = ThreadManager.OpenThread(bank, this.lockObject);
            Thread HELLThread = ThreadManager.HELLThread(bank);
            Choice choice = Choice.Exit;

            for(int i = 0; i < 5; i++)
            {
                bank.OpenAccount(1000);
            }
            do
            {
                choice = Menu();

                switch (choice)
                {
                    case Choice.Deposit:

                        if (ThreadManager.IsNotNullAndAlive(depositThread))
                        {
                            depositThread = ThreadManager.DepositThread(bank, this.lockObject);
                            depositThread.Start();
                        }
                        break;
                    case Choice.Withdraw:
                        if (ThreadManager.IsNotNullAndAlive(withdrawThread))
                        {
                            withdrawThread = ThreadManager.WithdrawThread(bank, this.lockObject);
                            withdrawThread.Start();
                        }
                        break;
                    case Choice.Transfer:
                        if (ThreadManager.IsNotNullAndAlive(transferThread))
                        {
                            transferThread = ThreadManager.TransferThread(bank, this.lockObject);
                            transferThread.Start();
                        }
                        break;
                    case Choice.Open:
                        if (ThreadManager.IsNotNullAndAlive(openAccountThread))
                        {
                            openAccountThread = ThreadManager.OpenThread(bank, this.lockObject);
                            openAccountThread.Start();
                        }
                        break;
                    case Choice.HELL:
                        if (ThreadManager.IsNotNullAndAlive(HELLThread))
                        {
                            HELLThread = ThreadManager.HELLThread(bank);
                            HELLThread.Start();
                            if (depositThread != null) depositThread.Join();
                            if (withdrawThread != null) withdrawThread.Join();
                            if (transferThread != null) transferThread.Join();
                            if (openAccountThread != null) openAccountThread.Join();
                            Console.WriteLine("All opened threads have successfully completed their tasks!");
                        }
                        break;
                    case Choice.Exit:
                        break;
                }
            } while (choice != Choice.Exit);
        }
        public Choice Menu()
        {
            Console.WriteLine("Welcome to Conto ARandom. Choose your chaos:");
            Console.WriteLine("1) Deposit random money to random accounts");
            Console.WriteLine("2) Withdraw random money from random accounts");
            Console.WriteLine("3) Transfer random money from random accounts to random accounts");
            Console.WriteLine("4) Open a random number of bank accounts");
            Console.WriteLine("5) WATCH HELL AS IT UNFOLDS");
            Console.WriteLine("6) Exit");
            int choice = Helpers.HelperMethods.ChooseNumber(1, 6);
            Choice choiceEnum = 0;
            switch (choice)
            {
                case 1:
                    choiceEnum = Choice.Deposit;
                    break;
                case 2:
                    choiceEnum = Choice.Withdraw;
                    break;
                case 3:
                    choiceEnum = Choice.Transfer;
                    break;
                case 4:
                    choiceEnum = Choice.Open;
                    break;
                case 5:
                    choiceEnum = Choice.HELL;
                    break;
                case 6:
                    choiceEnum = Choice.Exit;
                    break;
            }
            return choiceEnum;
        }

        
    }
}
