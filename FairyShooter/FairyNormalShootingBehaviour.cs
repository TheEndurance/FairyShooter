/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    /// <summary>
    /// Represents normal fairy shooting behaviour
    /// </summary>
    public class FairyNormalShootingBehaviour : IShootingBehaviour
    {
        public TimeSpan ShootInterval { get; }
        public TimeSpan? LastProjectileShot { get; set; }

        /// <summary>
        /// constructor for fairy normal shooting behaviour
        /// </summary>
        public FairyNormalShootingBehaviour()
        {
            ShootInterval = TimeSpan.FromMilliseconds(255);
            LastProjectileShot = null;

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
                if (LastProjectileShot == null || gameTime.TotalGameTime - LastProjectileShot >= ShootInterval)
                {
                    projectileManager.Shoot(ProjectileType.Regular, shooter);
                    LastProjectileShot = gameTime.TotalGameTime;
                }
           
        }
    }
}
