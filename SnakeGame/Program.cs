using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        public static void Main()
        {
            Walls walls = new Walls();
            Snake snake = new Snake();
            Game.MergeCoordinates();
            Food food = new Food();

            ConsoleKey consoleKey;

            while (true)
            {
                Game.DrawScreen();
                if (Console.KeyAvailable)
                {
                    consoleKey = Console.ReadKey(true).Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.UpArrow:
                            snake.SetMovementDirection(Directions.UP);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.SetMovementDirection(Directions.DOWN);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.SetMovementDirection(Directions.LEFT);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.SetMovementDirection(Directions.RIGHT);
                            break;
                    }
                }
                snake.Move();
                var collision = Game.DetectCollision();
                if (collision == CollisionType.SnakeToFood)
                {
                    food.CreateFoodCoordinate();
                }
                else if (collision == CollisionType.SnakeToWall)
                {
                    break;
                }
                Thread.Sleep(200); // bekle çünkü windows konsolu saniyede 30 tazeleme yapacak kadar hızlı değil.
            }
            Console.WriteLine("GAME OVER");
        }
    }
 }

