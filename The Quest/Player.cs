using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace The_Quest
{
    class Player : Mover
    {
        private Weapon equipedWeapon;

        public int HitPoints { get; private set; }

        public List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons
        {
            get 
            { 
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                    return names;
                }
            }
        }

        public Player(Game game, Point location) : base (game, location)
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
                    equipedWeapon = weapon;
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if(!game.WeaponInRoom.PickedUp)
            {
                // see if weapon is nearby, and possibly pick it up
            }
        }

        public void Attack(Direction direction, Random random)
        {
            // add attack code 
        }
    }
}
