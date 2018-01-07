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
        public SlowEnemyShootingBehaviour()
        {
            LastProjectileShot = null;
            _random = new Random();
        }

        public void Shoot(GameTime gameTime, ProjectileManager projectileManager, Sprite shooter)
        {
            if (!shooter.IsDead)
            {
                ShootInterval = TimeSpan.FromMilliseconds(_random.Next(500, 10000));
                if (LastProjectileShot == null || gameTime.TotalGameTime - LastProjectileShot >= ShootInterval)
                {
                    projectileManager.EnemyShoot(ProjectileType.Regular, shooter);
                    LastProjectileShot = gameTime.TotalGameTime;
                }
            }
        }

    }
}
