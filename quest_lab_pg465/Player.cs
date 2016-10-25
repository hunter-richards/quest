using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace quest_lab_pg465
{
    class Player : Mover
    {
        private Weapon equippedWeapon;

        public int HitPoints { get; private set; }

        private List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Player (Game game, Point location)
            : base(game, location)
        {
            HitPoints = 10;
        }

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                //see if the weapon is nearby, and possibly pick it up
                //i am responsible for this code - see pg 477
                if (Nearby(game.WeaponInRoom.Location, 1))
                {
                    inventory.Add(game.WeaponInRoom);
                    game.WeaponInRoom.PickUpWeapon(); //sets pickedup to true
                    if (inventory.Count == 1) //if it's the only weapon in inventory,
                        //go ahead and equip right away
                    {
                        Equip(game.WeaponInRoom.Name);
                    }
                }
            }
        }

        public void Attack(Direction direction, Random random)
        {
            //your code goes here - see pg 477 for description
            if (equippedWeapon != null)
            {
                if (equippedWeapon is IPotion)
                {
                    //use potion and remove from inventory
                    equippedWeapon.Attack(direction, random);
                    inventory.Remove(equippedWeapon);
                }
                else
                {
                    equippedWeapon.Attack(direction, random);
                }
            }
        }
    }
}
