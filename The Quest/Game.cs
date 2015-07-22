using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace The_Quest
{
    class Game
    {
        public IEnumerable<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }

        private Player player;
        public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }
        private int level = 0;

        public Rect boundaries;
        public Rect Boundaries { get { return boundaries; } }

        public Game(Rect boundaries)
        {
            this.boundaries = boundaries;
            player = new player(this, new Point(boundaries.Left + 10, boundaries.Top + 70));
        }

        public void Move(Direction direction, Random random)
        {
            player.Move(direction);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }

        public void Equip(string weaponName)
        {
            player.Equip(weaponName);   
        }

        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreasePlayerHealth(health, random);
        }

        public void Attack(Direction direction, Random random)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }

        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left +
                random.Next(Convert.ToInt32(boundaries.Right / 10 - boundaries.Left / 10)) * 10,
                boundaries.Top +
                random.Next(Convert.ToInt32(boundaries.Bottom / 10 - boundaries.Top / 10)) * 10); 
        }

        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>(){ new Bat(this, GetRandomLocation(random)), };
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
            }
        }

    }
}
