using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBanking.Helpers
{
    public static class HelperMethods
    {
        public static int ChooseNumber(int min, int max)
        {
            bool success = false;
            string? input;
            int number;

            while (true)
            {
                input = Console.ReadLine();
                success = int.TryParse(input, out number);
                if (!success)
                {
                    Console.WriteLine("Wrong input! Retry.");
                    continue;
                }
                if(number < min || number > max)
                {
                    Console.WriteLine("This option is not available. Retry.");
                    continue;
                }
                break;
            }

            return number;
        }
    }
}
