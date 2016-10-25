﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    public class RedPotion : Weapon, IPotion
    {
        public RedPotion(Game game, Point location)
            : base(game, location)
        {
            Used = false;
        }

        public override string Name
        {
            get { return "Red Potion"; }
        }

        public bool Used { get; private set; }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(10, random);
            Used = true;
        }
    }
}
