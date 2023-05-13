using Pattern.Logic;
using Pattern.Logic.Modules;
using Pattern.Logic.UI;

namespace Pattern
{
    internal class Program
    {
        public static GameManager GameManager { get; private set; }
        // https://stackoverflow.com/questions/5435460/console-application-how-to-update-the-display-without-flicker

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            GameManager = new GameManager();
            GameManager.StartGame();
        }
    }
}