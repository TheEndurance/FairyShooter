using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class SlowEnemyShootingBehaviour : IShootingBehaviour
    {

        private TimeSpan ShootInterval { get; set; }
        private TimeSpan? LastProjectileShot { get; set; }
        private Random _random;
        private int lowerBound;
        private int upperBound;
        public SlowEnemyShootingBehaviour()
        {
            LastProjectileShot = null;
            _random = new Random();
            lowerBound = 2500;
            upperBound = 10000;
        }

        public void Shoot(GameTime gameTime, ProjectileManager projectileManager, Sprite shooter)
        {
            if (!shooter.IsDead)
            {
                ShootInterval = TimeSpan.FromMilliseconds(_random.Next(lowerBound, upperBound));
                if (LastProjectileShot == null || gameTime.TotalGameTime - LastProjectileShot >= ShootInterval)
                {
                    projectileManager.EnemyShoot(ProjectileType.Slow, shooter);
                    LastProjectileShot = gameTime.TotalGameTime;
                    lowerBound -= 50;
                    upperBound -= 50;
                }
            }
        }

    }
}
