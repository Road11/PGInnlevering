using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Movement
    {
        private int x;
        private int y;

        public Movement(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public Movement(Movement input)
        {
            this.x = input.x;
            this.y = input.y;
        }
    }
}
