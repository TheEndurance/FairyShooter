using System;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public interface IShootingBehaviour
    {
        TimeSpan ShootInterval { get; }
        TimeSpan? LastBulletShot { get; set; }
        void Shoot(GameTime gameTime, ProjectileManager projectileManager,Sprite sprite);
    }
}
