using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location)
            : base(game, location, 6) //6 hit points passed to base class constructor
        {
            //"probably won't need a subclass constructor because
            //base class handles everything"
        }
        public override void Move(Random random)
        {
            //your code here
            if (HitPoints >= 1)
            {

                if (Nearby(game.PlayerLocation, 1))
                {
                    Random randomDamage = new Random();
                    game.HitPlayer(2, randomDamage);
                }
                else
                {
                    if (random.Next(2) == 0)
                    {
                        //move toward player (50% chance)
                        Direction playerDirection = FindPlayerDirection(game.PlayerLocation);
                        base.location = Move(playerDirection, game.Boundaries);
                    }
                    else
                    {
                        //move in a random direction (50% chance)
                        Array directions = Enum.GetValues(typeof(Direction));
                        Direction randomDirection =
                            (Direction)directions.GetValue(random.Next(directions.Length));
                        base.location = Move(randomDirection, game.Boundaries);
                    }
                }
            }
        }
    }
}
