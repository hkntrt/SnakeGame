using System.Collections.Generic;


namespace SnakeGame
{
    internal class Walls
    {
        private List<Coordinate> stoneCoordinates;

        public Walls()
        {
            stoneCoordinates = new List<Coordinate>();
            CalculateStoneCoordinates(Game.width, Game.height);
        }

        private void CalculateStoneCoordinates(int width, int height)
        {
            //en ve boya göre bir dikdörtgen/kare için duvarları hesaplıyor. 
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == 0 || y == height - 1)
                    {
                        Game.wallCoordinates.Add(new Coordinate(x, y));
                        
                    }
                    else
                    {
                        if (x == 0 || x == width -1)
                        {
                            Game.wallCoordinates.Add(new Coordinate(x, y));
                        }
                    }
                }
            }
        }

        public List<Coordinate> GetCoordinates()
        {
            return stoneCoordinates;
        }
    }
}
