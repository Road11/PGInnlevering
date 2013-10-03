// Note from author Tomas Sandnes:
// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code though! And I can now (proudly?) say that this is the uggliest short piece of code I've ever worked with! :-)
//          (And yes, it could have been a lot ugglier! But the idea wasn't to make it fuggly-uggly, just funny-uggly, sweet-uggly, or whatever you want to call it.)
//
//      - Tomas
//

using SnakeGame;

namespace SnakeMess
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    //using System.Data;

/*    internal class Point
    {
        public int  X { get; set; }
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
    }*/

    internal class SnakeMeSs
    {
        public static void Main(string[] a)
        {
            SnakePart snake = new SnakePart();
            bool gameOver = false;
            bool pause = false;
            bool inuse = false;
            string newKey = "right"; // 0 = up, 1 = right, 2 = down, 3 = left
            string prevKey = newKey;
            int boardWidth = Console.WindowWidth; //
            int boardHeight = Console.WindowHeight; //

            var rng = new Random();
            var point = new Point();
            var snakeParts = new List<Point>();

            Console.CursorVisible = false;
            for (int i = 0; i < 4; i++)
            {
                snakeParts.Add(new Point(10, 10));
            }

            

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");

               Food food = new Food();

            food.DrawFood();
            
/*            while (true)
            {
                Point.X = rng.Next(0, boardWidth);
                Point.Y = rng.Next(0, boardHeight);
                bool spot = true;
                foreach (Point p in snakeParts)
                {
                    if (p.X == Point.X && p.Y == Point.Y)
                    {
                        spot = false;
                        break;
                    }
                }
                if (spot)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(Point.X, Point.Y);
                    Console.Write("$");
                    break;
                }
            }*/
            var time = new Stopwatch();
            time.Start();
            while (!gameOver)
            {

/*                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo controls = Console.ReadKey(true); // 0 = up, 1 = right, 2 = down, 3 = left
                    if (controls.Key == ConsoleKey.Escape)
                    {
                        gameOver = true;
                    }
                    else if (controls.Key == ConsoleKey.Spacebar)
                    {
                        pause = !pause;
                    }
                    else if (controls.Key == ConsoleKey.UpArrow && prevKey != "down")
                    {
                        newKey = "up";
                    }
                    else if (controls.Key == ConsoleKey.RightArrow && prevKey != "left")
                    {
                        newKey = "right";
                    }
                    else if (controls.Key == ConsoleKey.DownArrow && prevKey != "up")
                    {
                        newKey = "down";
                    }
                    else if (controls.Key == ConsoleKey.LeftArrow && prevKey != "right")
                    {
                        newKey = "left";
                    }
                }*/
                if (!pause)
                {
                    if (time.ElapsedMilliseconds < 100)
                    {
                        continue;
                    }
                    time.Restart();

                    Input input = new Input();
                    input.CheckInput();
/*                    var tail = new Point(snakeParts.First());
                    var head = new Point(snakeParts.Last());
                    var newHead = new Point(head);*/
/*                    switch (newKey)
                    {
                        case "up":
                            newHead.Y -= 1;
                            break;
                        case "right":
                            newHead.X += 1;
                            break;
                        case "down":
                            newHead.Y += 1;
                            break;
                        default:
                            newHead.X -= 1;
                            break;
                    }*/
                    if (snake.newHead.X < 0 || snake.newHead.X >= boardWidth)
                    {
                        gameOver = true;
                    }
                    else if (snake.newHead.Y < 0 || snake.newHead.Y >= boardHeight)
                    {
                        gameOver = true;
                    }
                    if (snake.newHead.X == point.X && snake.newHead.Y == point.Y)
                    {
                        if (snakeParts.Count + 1 >= boardWidth * boardHeight)
                        {
                            // No more room to place apples -- game over.
                            gameOver = true;
                        }
                        else
                        {
                            while (true)
                            {
                                point.X = rng.Next(0, boardWidth);
                                point.Y = rng.Next(0, boardHeight);
                                bool found = true;
                                foreach (Point i in snakeParts)
                                {
                                    if (i.X == point.X && i.Y == point.Y)
                                    {
                                        found = false;
                                        break;
                                    }
                                }
                                if (found)
                                {
                                    inuse = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!inuse)
                    {
                        snake.snakeParts.RemoveAt(0);
                        foreach (Point x in snakeParts)
                        {
                            if (x.X == snake.newHead.X && x.Y == snake.newHead.Y)
                            {
                                // Death by accidental self-cannibalism.
                                gameOver = true;
                                break;
                            }
                        }
                    }
                    if (!gameOver)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(snake.head.X, snake.head.Y);
                        Console.Write("O");
                        if (!inuse)
                        {
                            Console.SetCursorPosition(snake.tail.X, snake.tail.Y);
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(point.X, point.Y);
                            Console.Write("$");
                            inuse = false;
                        }
                        snake.snakeParts.Add(snake.newHead);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(snake.newHead.X, snake.newHead.Y);
                        Console.Write("@");
                        prevKey = newKey;
                    }
                }
            }
        }
    }
}