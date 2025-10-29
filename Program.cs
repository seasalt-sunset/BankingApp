using ThreadingBanking.Entities;
using ThreadingBanking.UI;

namespace ThreadingBanking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserInterface ui = new UserInterface();
                ui.start();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error!!!!!....????!?!!?!! {e.Message}");
            }
        }
    }
}
