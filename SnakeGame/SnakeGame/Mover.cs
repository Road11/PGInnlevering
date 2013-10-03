using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Mover
    {
        SnakePart snake = new SnakePart();

        public void MoveUp()
        {
            snake.newHead.Y -= 1;
        }

        public void MoveDown()
        {
            snake.newHead.Y += 1;
        }

        public void MoveLeft()
        {
            snake.newHead.X -= 1;
        }

        public void MoveRight()
        {
            snake.newHead.X += 1;
        } 
    }
}