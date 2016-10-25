using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location)
            : base(game, location) { }

        public override string Name
        {
            get { return "Mace"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            //code goes here
            //mace has radius of 20 and 6 points of damage
            switch (direction)
            {
                case Direction.Up:
                    if (DamageEnemy(Direction.Up, 20, 6, random) == false)
                    {
                        if (DamageEnemy(Direction.Right, 20, 6, random) == false)
                        {
                            if (DamageEnemy(Direction.Left, 20, 6, random) == false)
                            {
                                DamageEnemy(Direction.Down, 20, 6, random);
                            }
                        }
                    }
                    break;
                case Direction.Right:
                    if (DamageEnemy(Direction.Right, 20, 6, random) == false)
                    {
                        if (DamageEnemy(Direction.Down, 20, 6, random) == false)
                        {
                            if (DamageEnemy(Direction.Up, 20, 6, random) == false)
                            {
                                DamageEnemy(Direction.Left, 20, 6, random);
                            }
                        }
                    }
                    break;
                case Direction.Down:
                    if (DamageEnemy(Direction.Down, 20, 6, random) == false)
                    {
                        if (DamageEnemy(Direction.Left, 20, 6, random) == false)
                        {
                            if (DamageEnemy(Direction.Right, 20, 6, random) == false)
                            {
                                DamageEnemy(Direction.Up, 20, 6, random);
                            }
                        }
                    }
                    break;
                case Direction.Left:
                    if (DamageEnemy(Direction.Left, 20, 6, random) == false)
                    {
                        if (DamageEnemy(Direction.Up, 20, 6, random) == false)
                        {
                            if (DamageEnemy(Direction.Down, 20, 6, random) == false)
                            {
                                DamageEnemy(Direction.Right, 20, 6, random);
                            }
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
