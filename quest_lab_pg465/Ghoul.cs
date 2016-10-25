using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location)
            : base(game, location, 10)
        {
            //don't need subclass constructor
        }

        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                if (Nearby(game.PlayerLocation, 1))
                {
                    Random randomGhoulDamage = new Random();
                    game.HitPlayer(4, randomGhoulDamage);
                }
                else
                {
                    if (random.Next(3) > 0)
                    {
                        //move toward player
                        Direction playerDirection = FindPlayerDirection(game.PlayerLocation);
                        base.location = Move(playerDirection, game.Boundaries);
                    }
                }
            }
        }
    }
}
