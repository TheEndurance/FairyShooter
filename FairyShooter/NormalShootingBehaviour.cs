using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    public class NormalShootingBehaviour : IShootingBehaviour
    {
        public TimeSpan ShootInterval { get; }
        public TimeSpan? LastProjectileShot { get; set; }
        public NormalShootingBehaviour()
        {
            ShootInterval = TimeSpan.FromMilliseconds(255);
            LastProjectileShot = null;

        }

        public void Shoot(GameTime gameTime, ProjectileManager projectileManager, Sprite shooter)
        {
           
                if (LastProjectileShot == null || gameTime.TotalGameTime - LastProjectileShot >= ShootInterval)
                {
                    projectileManager.Shoot(ProjectileType.Regular, shooter.Position.X, shooter.Position.Y, shooter.Width, shooter.Height, shooter.GameBounds);
                    LastProjectileShot = gameTime.TotalGameTime;
                }
           
        }
    }
}
