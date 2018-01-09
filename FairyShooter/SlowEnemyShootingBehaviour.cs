/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    /// <summary>
    /// Slow enemy shooting behaviour
    /// </summary>
    public class SlowEnemyShootingBehaviour : IShootingBehaviour
    {

        private TimeSpan ShootInterval { get; set; }
        private TimeSpan? LastProjectileShot { get; set; }
        private Random _random;
        private int lowerBound;
        private int upperBound;

        /// <summary>
        /// Constructor for slow enemy shooting behaviour
        /// </summary>
        public SlowEnemyShootingBehaviour()
        {
            LastProjectileShot = null;
            _random = new Random();
            lowerBound = 2500;
            upperBound = 10000;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="projectileManager"></param>
        /// <param name="shooter"></param>
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
