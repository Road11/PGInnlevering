using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Input
    {
        Mover mover = new Mover();
        public enum KeyOptions {Left, Right, Up, Down, Pause, Quit}
        public static KeyOptions ChosenKey { get; set; }

        public void CheckInput()
        {            
            ConsoleKeyInfo buttonPressed = Console.ReadKey(true);

            switch (buttonPressed.Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    ChosenKey = KeyOptions.Left;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    ChosenKey = KeyOptions.Right;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    ChosenKey = KeyOptions.Up;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    ChosenKey = KeyOptions.Down;
                    break;
                case ConsoleKey.Spacebar:
                    ChosenKey = KeyOptions.Pause;
                    break;
                case ConsoleKey.Escape:
                    ChosenKey = KeyOptions.Quit;
                    break;
            }

            switch (ChosenKey)
            {
                case KeyOptions.Left:
                    mover.MoveLeft();
                    break;
                case KeyOptions.Right:
                    mover.MoveRight();
                    break;
                case KeyOptions.Up:
                    mover.MoveUp();
                    break;
                case KeyOptions.Down:
                    mover.MoveDown();
                    break;
                case KeyOptions.Pause:
                    //do this
                    break;
                case KeyOptions.Quit:
                    //do this
                    break;
            }
        }
    }
}
