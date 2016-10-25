using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location)
            : base(game, location, 8)
        {
            //"probably won't need subclass constructor"
        }
        public override void Move(Random random)
        {
            if (HitPoints >= 1)
            {
                if (Nearby(game.PlayerLocation, 1))
                {
                    Random randomGhostDamage = new Random();
                    game.HitPlayer(3, randomGhostDamage);
                }
                else
                {
                    if (random.Next(3) == 2)
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
