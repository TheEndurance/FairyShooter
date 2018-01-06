using System;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public interface IShootingBehaviour
    {
        TimeSpan ShootInterval { get; }
        TimeSpan? LastProjectileShot { get; set; }
        void Shoot(GameTime gameTime, ProjectileManager projectileManager,Sprite sprite);
    }
}
