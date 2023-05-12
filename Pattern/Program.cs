using Pattern.Logic.Modules;

namespace Pattern
{
    internal class Program
    {
        private static InputManager InputManager { get; set; }

        // https://stackoverflow.com/questions/5435460/console-application-how-to-update-the-display-without-flicker

        static void Main(string[] args)
        {
            InputManager = new InputManager();

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(120, 30);

            var box = new Logic.UI.PatternBox();

            box.Display();

            InputManager.HandleInput();
        }
    }
}