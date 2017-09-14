using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    public class NormalShootingBehaviour : IShootingBehaviour
    {
        public TimeSpan ShootInterval { get; }
        public TimeSpan? LastBulletShot { get; set; }
        public NormalShootingBehaviour()
        {
            ShootInterval = TimeSpan.FromMilliseconds(255);
            LastBulletShot = null;

        }



        public void Shoot(GameTime gameTime, ProjectileManager projectileManager, Sprite shooter)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (LastBulletShot == null || gameTime.TotalGameTime - LastBulletShot >= ShootInterval)
                {
                    projectileManager.Shoot(ProjectileType.Regular, shooter.Location.X, shooter.Location.Y, shooter.Width, shooter.Height, shooter.GameBounds);
                    LastBulletShot = gameTime.TotalGameTime;
                }
            }
        }
    }
}
