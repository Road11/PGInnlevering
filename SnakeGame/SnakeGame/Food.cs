using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Food 
    {
        readonly Random rand = new Random();
        readonly Point point = new Point();

        public void DrawFood()
        {
            var snakeFood = new List<Point>();
            while (true)
            {
                point.X = rand.Next(0, point.BoardWidth);
                point.Y = rand.Next(0, point.BoardHeight);
                bool spot = true;
                foreach (Point p in snakeFood)
                {
                    if (p.X == point.X && p.Y == point.Y)
                    {
                        spot = false;
                    }
                }
                if (spot)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write("$");
                    break;
                }
            }
        }
    }
}
