using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace The_Quest
{
    abstract class Weapon : Mover
    {
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location)
            : base(game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeapon() { PickedUp = true; }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius / 2; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    //if (Nearby(enemy.Location, target, distance))
                    if (Nearby(target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                //Move(direction, target, game.Boundaries);
                target = Move(direction, game.Boundaries);
            }
            return false;
        }
    }

    class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location) { }

        public override string Name
        {
            get { return "Sword"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            // Stuff here
        }
    }

    class Bow : Weapon
    {
        public Bow(Game game, Point location) : base(game, location) { }

        public override string Name
        {
            get { return "Bow"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            // Stuff here
        }
    }

    class Mace : Weapon
    {
        public Mace(Game game, Point location) : base(game, location) { }

        public override string Name
        {
            get { return "Mace"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            // Stuff here
        }
    }

    class BluePotion : Weapon
    {
        public BluePotion(Game game, Point location) : base(game, location) { }

        public override string Name
        {
            get { return "BluePotion"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            // Stuff here
        }
    }

    class RedPotion : Weapon
    {
        public RedPotion(Game game, Point location) : base(game, location) { }

        public override string Name
        {
            get { return "RedPotion"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            // Stuff here
        }
    }
}
