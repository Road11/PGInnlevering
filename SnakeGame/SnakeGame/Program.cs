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

namespace SnakeMess
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    //using System.Data;

    internal class movement
    {
        private int X;
        private int Y;

        public movement(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public movement(movement input)
        {
            this.X = input.X;
            this.Y = input.Y;
        }
    }

    internal class SnakeMeSs
    {
        public static void Main(string[] a)
        {
            bool gameOver = false;
            bool pause = false;
            bool inuse = false;
            string newKey = "right"; // 0 = up, 1 = right, 2 = down, 3 = left
            string prevKey = newKey;
            int boardWidth = Console.WindowWidth;
            int boardHeight = Console.WindowHeight;

            var rng = new Random();
            var movement = new movement();
            var snakeParts = new List<movement>();

            Console.CursorVisible = false;

            for (int i = 0; i < 4; i++)
            {
                snakeParts.Add(new movement(10, 10));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");

            while (true)
            {
                movement.X = rng.Next(0, boardWidth);
                movement.Y = rng.Next(0, boardHeight);
                bool spot = true;
                foreach (movement i in snakeParts)
                {
                    if (i.X == movement.X && i.Y == movement.Y)
                    {
                        spot = false;
                        break;
                    }
                }
                if (spot)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(movement.X, movement.Y);
                    Console.Write("$");
                    break;
                }
            }
            var time = new Stopwatch();
            time.Start();
            while (!gameOver)
            {
                if (Console.KeyAvailable)
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
                }
                if (!pause)
                {
                    if (time.ElapsedMilliseconds < 100)
                    {
                        continue;
                    }
                    time.Restart();
                    var tail = new movement(snakeParts.First());
                    var head = new movement(snakeParts.Last());
                    var newHead = new movement(head);
                    switch (newKey)
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
                        case "left":
                        default:
                            newHead.X -= 1;
                            break;
                    }
                    if (newHead.X < 0 || newHead.X >= boardWidth)
                    {
                        gameOver = true;
                    }
                    else if (newHead.Y < 0 || newHead.Y >= boardHeight)
                    {
                        gameOver = true;
                    }
                    if (newHead.X == movement.X && newHead.Y == movement.Y)
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
                                movement.X = rng.Next(0, boardWidth);
                                movement.Y = rng.Next(0, boardHeight);
                                bool found = true;
                                foreach (movement i in snakeParts)
                                {
                                    if (i.X == movement.X && i.Y == movement.Y)
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
                        snakeParts.RemoveAt(0);
                        foreach (movement x in snakeParts)
                        {
                            if (x.X == newHead.X && x.Y == newHead.Y)
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
                        Console.SetCursorPosition(head.X, head.Y);
                        Console.Write("O");
                        if (!inuse)
                        {
                            Console.SetCursorPosition(tail.X, tail.Y);
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(movement.X, movement.Y);
                            Console.Write("$");
                            inuse = false;
                        }
                        snakeParts.Add(newHead);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(newHead.X, newHead.Y);
                        Console.Write("@");
                        prevKey = newKey;
                    }
                }
            }
        }
    }
}