using System;

namespace SnakeGame
{
    internal class Food
    {
        public Food()
        {
            CreateFoodCoordinate();
        }

        public void CreateFoodCoordinate()
        {
            Random random = new Random();
            while (true)
            {
                int x = random.Next(Game.width - 1);
                int y = random.Next(Game.height - 1);
                Coordinate tempCoordinate = new Coordinate(x, y);
                if (!Game.occupiedCoordinates.Contains(tempCoordinate))
                {
                    Game.foodCoordinate = tempCoordinate;
                    break;
                }
            }
        }


    }
}
