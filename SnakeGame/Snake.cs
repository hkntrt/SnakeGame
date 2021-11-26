using System.Collections.Generic;

namespace SnakeGame
{
    public enum Directions
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    internal class Snake
    {
        private int snakeLength = 3;
        private Directions movementDirection = Directions.LEFT;
        private List<Coordinate> oldCoordinates;

        public Snake()
        {
            createInitialSnakeCoordinates();
            oldCoordinates = new List<Coordinate>();
        }

        private void createInitialSnakeCoordinates()
        {
            //Yılanı X birim uzunluta duvarlara denk gelmeyecek şekilde hesaplıyorum.
            //Bunun için platformun en ve boyunun yarısını alıyorum, yılan platformun ortalarında bir yerde belirecek
            for (int i = 0; i < snakeLength; i++)
            {
                var x = Game.width - (Game.width / 2) + i;
                var y = Game.height - (Game.height / 2);
                Game.snakeCoordinates.Add(new Coordinate(x,y));
            }
        }

        public void Move()
        {
            oldCoordinates.Clear();
            foreach (var item in Game.snakeCoordinates)
            {
                oldCoordinates.Add(item);
            }
            switch (movementDirection)
            {
                case Directions.UP:
                    Game.snakeCoordinates[0] = new Coordinate(Game.snakeCoordinates[0].X, Game.snakeCoordinates[0].Y - 1);
                    break;
                case Directions.DOWN:
                    Game.snakeCoordinates[0] = new Coordinate(Game.snakeCoordinates[0].X, Game.snakeCoordinates[0].Y + 1);
                    break;
                case Directions.LEFT:
                    Game.snakeCoordinates[0] = new Coordinate(Game.snakeCoordinates[0].X - 1, Game.snakeCoordinates[0].Y);
                    break;
                case Directions.RIGHT:
                    Game.snakeCoordinates[0] = new Coordinate(Game.snakeCoordinates[0].X + 1, Game.snakeCoordinates[0].Y);
                    break;
            }
            for (int i = 1; i < snakeLength; i++)
            {
                Game.snakeCoordinates[i] = oldCoordinates[i-1];

            }
            
        }

        public void SetMovementDirection(Directions movementDirection)
        {
            switch (movementDirection)
            {
                case Directions.UP:
                    this.movementDirection = Directions.UP;
                    break;
                case Directions.DOWN:
                    this.movementDirection = Directions.DOWN;
                    break;
                case Directions.LEFT:
                    this.movementDirection = Directions.LEFT;
                    break;
                case Directions.RIGHT:
                    this.movementDirection = Directions.RIGHT;
                    break;
            }
        }
    }
}
