using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public enum CollisionType
    {
        SnakeToWall,
        SnakeToFood,
        None
    }
    internal static class Game
    {
        public static int width = 30;
        public static int height = 15;
        public static List<Coordinate> occupiedCoordinates = new List<Coordinate>();
        public static List<Coordinate> wallCoordinates = new List<Coordinate>();
        public static List<Coordinate> snakeCoordinates = new List<Coordinate>();
        public static Coordinate foodCoordinate = new Coordinate();

        public static void MergeCoordinates()
        {
            occupiedCoordinates.Clear();
            occupiedCoordinates.AddRange(wallCoordinates);
            occupiedCoordinates.AddRange(snakeCoordinates);
        }

        public static CollisionType DetectCollision()
        {
            foreach (var item in snakeCoordinates)
            {
                if (item == foodCoordinate)
                {
                    return CollisionType.SnakeToFood;
                }
            }
            foreach (var item in snakeCoordinates)
            {
                if (wallCoordinates.Contains(item))
                {
                    return CollisionType.SnakeToWall;
                }
            }

            return CollisionType.None;
        }

        public static void DrawScreen()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Coordinate currentCoordinate = new Coordinate(x, y);
                    if (foodCoordinate == currentCoordinate)
                    {
                        Console.Write('O'); 
                    }
                    else if (snakeCoordinates.Contains(currentCoordinate))
                    {
                        Console.Write('*');
                    }
                    else if (wallCoordinates.Contains(currentCoordinate))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
