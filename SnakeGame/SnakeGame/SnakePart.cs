using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    class SnakePart
    {
       public List<Point> snakeParts;
       public Point tail;
       public Point head;
       public Point newHead;

        public void SnakeDraw()
        {
            snakeParts = new List<Point>();
            tail = new Point(snakeParts.First());
            head = new Point(snakeParts.Last());
            newHead = new Point(head);
        }
    }
}