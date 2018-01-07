using System;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public interface IShootingBehaviour
    {
        void Shoot(GameTime gameTime, ProjectileManager projectileManager,Sprite sprite);
    }
}
