using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FairyShooter
{
    public class ProjectileManager
    {
        public IList<Projectile> Projectiles { get; }
        private Texture2D ProjectileTexture;

        public ProjectileManager(IList<Projectile> Projectiles, Texture2D ProjectileTexture)
        {
            this.Projectiles = Projectiles;
            this.ProjectileTexture = ProjectileTexture;
        }

        public void Shoot(ProjectileType projectileType, float X, float Y, int Width, int Height, Rectangle GameBounds)
        {
            if (projectileType == ProjectileType.Regular)
            {
                Projectiles.Add(new Projectile(ProjectileTexture,
                    new Vector2(X + Width / 2, Y), GameBounds,new RegularProjectileMovement()));
            }
        }
    }
}
