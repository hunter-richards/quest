using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    public abstract class Mover
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        //first nearby method - modified from original to clean up code
        public bool Nearby(Point locationToCheck, int distance)
        {
            return Nearby(location, locationToCheck, distance);
        }
        //now for the overloaded nearby method
        public bool Nearby(Point firstLocationToCheck, Point secondLocationToCheck,
            int distance)
        {
            if (Math.Abs(firstLocationToCheck.X - secondLocationToCheck.X) < distance &&
                (Math.Abs(firstLocationToCheck.Y - secondLocationToCheck.Y) < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //original Move method - altered to get rid of duplicate code
        public Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = location;
            return Move(direction, newLocation, boundaries);
        }
        //now for the overloaded Move method
        public Point Move(Direction direction, Point point, Rectangle boundaries)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (point.Y - MoveInterval >= boundaries.Top)
                        point.Y -= MoveInterval;
                    break;
                case Direction.Down:
                    if (point.Y + MoveInterval <= boundaries.Bottom)
                        point.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (point.X - MoveInterval >= boundaries.Left)
                        point.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (point.X + MoveInterval <= boundaries.Right)
                        point.X += MoveInterval;
                    break;
                default: break;
            }
            return point;
        }
    }
}
