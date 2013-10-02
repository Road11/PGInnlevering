using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeInnlevering
{
    using SnakeMess;

    class InputHandler
    {
        //Midlertidig inputhandler, funker ikke enda, må fikses litt på og opprettes andre klasser
        public enum AvailableKeys
        {
            Right,Left, Up, Down, Quit, Pause
        }

        public static AvailableKeys ChosenKey { get; set; }

        private static void CheckConsoleInput()
        {
            switch (ChosenKey)
            {
                case AvailableKeys.Right:               
                    break;
                case AvailableKeys.Left:
                    //blabla.Direction.Left;
                    break;
                case AvailableKeys.Up:
                    //...
                    break;
                case AvailableKeys.Down:
                    //...
                    break;
                case AvailableKeys.Quit:
                    //...
                    break;
                case AvailableKeys.Pause:
                    //..
                    break;
            }

            ConsoleKeyInfo buttonPressed = Console.ReadKey(true);

            buttonPressed = Console.ReadKey(true);
            
            switch (buttonPressed.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    ChosenKey = AvailableKeys.Up;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    ChosenKey = AvailableKeys.Right;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    ChosenKey = AvailableKeys.Down;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                   ChosenKey = AvailableKeys.Left;
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.End:
                    ChosenKey = AvailableKeys.Quit;
                    break;
                case ConsoleKey.Spacebar:
                    ChosenKey = AvailableKeys.Pause;
                    break;
            }
        }
    }
}

