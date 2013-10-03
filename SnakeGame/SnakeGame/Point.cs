using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Point
    {
        public int BoardHeight = Console.WindowHeight;
        public int BoardWidth = Console.WindowWidth;
        public int X { get; set; }
        public int Y { get; set; }
 
        public Point(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Point input)
        {
            this.X = input.X;
            this.Y = input.Y;
        }
    }
}
