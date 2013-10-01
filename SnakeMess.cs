﻿// Note from author Tomas Sandnes:
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

using System;
using System.Collections.Generic;

namespace SnakeMess
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System;
    using System.Diagnostics;
    using System.CodeDom;
	class coord
	{
		public int X; public int Y;
        public coord( int x = 0, int y = 0 ) { X = x; Y = y; }
        public coord( coord input ) { X = input.X; Y = input.Y; }
    }

    class SnakeMeSs
	{
		public static void Main( string[] a )
		{
            bool gg = false, pause = false, inuse = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
            int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
            Random rng = new Random();
            coord app = new coord();
            List<coord> snake = new List<coord>();
			snake.Add( new coord( 10, 10 ) ); snake.Add( new coord( 10, 10 ) ); snake.Add( new coord( 10, 10 ) ); snake.Add( new coord( 10, 10 ) );
            Console.CursorVisible = false; 
            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition( 10, 10 ); Console.Write( "@" );
			while ( true )
			{
				app.X = rng.Next( 0, boardW ); app.Y = rng.Next( 0, boardH );
				bool spot = true;
				foreach ( coord i in snake )
					if ( i.X == app.X && i.Y == app.Y )
					{
						spot = false;
						break;
					}
				if ( spot )
				{
					Console.ForegroundColor = ConsoleColor.Red; Console.SetCursorPosition( app.X, app.Y ); Console.Write( "$" );
					break;
				}
			}
			Stopwatch t = new Stopwatch();
			t.Start();
			while ( !gg )
			{
				if ( Console.KeyAvailable )
				{
					ConsoleKeyInfo cki = Console.ReadKey( true );
					if ( cki.Key == ConsoleKey.Escape )
						gg = true;
					else if ( cki.Key == ConsoleKey.Spacebar )
						pause = !pause;
					else if ( cki.Key == ConsoleKey.UpArrow && last != 2 )
						newDir = 0;
					else if ( cki.Key == ConsoleKey.RightArrow && last != 3 )
						newDir = 1;
					else if ( cki.Key == ConsoleKey.DownArrow && last != 0 )
						newDir = 2;
					else if ( cki.Key == ConsoleKey.LeftArrow && last != 1 )
						newDir = 3;
				}
				if ( !pause )
				{
					if ( t.ElapsedMilliseconds < 100 )
						continue;
					t.Restart();
					coord tail = new coord(snake.First());
					coord head = new coord(snake.Last());
					coord newH = new coord(head);
					switch ( newDir )
					{
						case 0:
							newH.Y -= 1;
							break;
						case 1:
							newH.X += 1;
							break;
						case 2:
							newH.Y += 1;
							break;
						case 3:
						default:
							newH.X -= 1;
							break;
					}
					if ( newH.X < 0 || newH.X >= boardW )
						gg = true;
					else if ( newH.Y < 0 || newH.Y >= boardH )
						gg = true;
					if ( newH.X == app.X && newH.Y == app.Y )
					{
						if ( snake.Count + 1 >= boardW * boardH )
							// No more room to place apples -- game over.
							gg = true;
						else
						{
							while ( true )
							{
								app.X = rng.Next( 0, boardW ); app.Y = rng.Next( 0, boardH );
								bool found = true;
								foreach ( coord i in snake )
									if ( i.X == app.X && i.Y == app.Y )
									{
										found = false;
										break;
									}
								if ( found )
								{
									inuse = true;
									break;
								}
							}
						}
					}
					if ( !inuse )
					{
						snake.RemoveAt( 0 );
						foreach ( coord x in snake )
							if ( x.X == newH.X && x.Y == newH.Y )
							{
								// Death by accidental self-cannibalism.
								gg = true;
								break;
							}
					}
					if ( !gg )
					{
						Console.ForegroundColor = ConsoleColor.Green; 
                        Console.SetCursorPosition( head.X, head.Y ); Console.Write( "O" );
						if ( !inuse )
						{
							Console.SetCursorPosition( tail.X, tail.Y ); Console.Write( " " );
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red; Console.SetCursorPosition( app.X, app.Y ); Console.Write( "$" );
							inuse = false;
						}
						snake.Add( newH );
						Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition( newH.X, newH.Y ); Console.Write( "@" );
						last = newDir;
					}
				}
			}
		}
	}


}