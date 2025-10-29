using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBanking.UI
{
    public class UserInterface
    {
        public void start()
        {
            do
            {
                Choice choice = Menu();

                switch (choice)
                {
                    case Choice.Deposit:
                        break;
                    case Choice.Withdraw:
                        break;
                    case Choice.Transfer:
                        break;
                    case Choice.HELL:
                        break;
                    case Choice.Exit:
                        break;
                }

            } while (true);
        }
        public Choice Menu()
        {
            Console.WriteLine("Welcome to Conto ARandom. Choose your chaos:");
            Console.WriteLine("1) Deposit random money to random accounts");
            Console.WriteLine("2) Withdraw random money from random accounts");
            Console.WriteLine("3) Transfer random money from random accounts to random accounts");
            Console.WriteLine("4) WATCH HELL AS IT UNFOLDS");
            Console.WriteLine("5) Exit");
            int choice = Helpers.HelperMethods.ChooseNumber(1, 5);
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
                    choiceEnum = Choice.HELL;
                    break;
                case 5:
                    choiceEnum = Choice.Exit;
                    break;
            }
            return choiceEnum;
        }

        
    }
}
