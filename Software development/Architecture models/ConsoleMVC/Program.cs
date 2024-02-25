using ConsoleMVC.Controllers;

namespace ConsoleMVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tipController = new TipController();
            tipController.Execute();
        }
    }
}
