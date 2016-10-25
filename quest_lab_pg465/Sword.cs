using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Sword"; } }

        public override void Attack(Direction direction, Random random)
        {
            //Your code goes here - see pg 481
            switch (direction)
            {
                case Direction.Up:
                    if (DamageEnemy(Direction.Up, 10, 3, random) == false)
                    {
                        if (DamageEnemy(Direction.Right, 10, 3, random) == false)
                        {
                            DamageEnemy(Direction.Left, 10, 3, random);
                        }
                    }
                    break;
                case Direction.Right:
                    if (DamageEnemy(Direction.Right, 10, 3, random) == false)
                    {
                        if (DamageEnemy(Direction.Down, 10, 3, random) == false)
                        {
                            DamageEnemy(Direction.Up, 10, 3, random);
                        }
                    }
                    break;
                case Direction.Down:
                    if (DamageEnemy(Direction.Down, 10, 3, random) == false)
                    {
                        if (DamageEnemy(Direction.Left, 10, 3, random) == false)
                        {
                            DamageEnemy(Direction.Right, 10, 3, random);
                        }
                    }
                    break;
                case Direction.Left:
                    if (DamageEnemy(Direction.Left, 10, 3, random) == false)
                    {
                        if (DamageEnemy(Direction.Up, 10, 3, random) == false)
                        {
                            DamageEnemy(Direction.Down, 10, 3, random);
                        }
                    }
                    break;
                default: break;
            }
        }
        
    }
}
