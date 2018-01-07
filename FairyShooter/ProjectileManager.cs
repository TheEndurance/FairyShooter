using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace FairyShooter
{
    public class ProjectileManager
    {
        public IList<Projectile> PlayerProjectiles = new List<Projectile>();
        public IList<Projectile> EnemyProjectiles = new List<Projectile>();

        public IEnumerable<Projectile> AllProjectiles => EnemyProjectiles.Union(PlayerProjectiles);

        private readonly Texture2D _projectileTexture;

        public ProjectileManager(Texture2D ProjectileTexture)
        {
            _projectileTexture = ProjectileTexture;
        }

        public void Shoot(ProjectileType projectileType, Sprite shooter)
        {
            Vector2 shotLocation = new Vector2(shooter.Position.X + shooter.Width / 2.6f, shooter.Position.Y);
            Projectile projectile = new Projectile(_projectileTexture, shotLocation, shooter, shooter.GameBounds);

            switch (projectileType)
            {
                case ProjectileType.Regular:
                    break;
            }
            PlayerProjectiles.Add(projectile);
        }

        public void EnemyShoot(ProjectileType projectileType, Sprite shooter)
        {

            Vector2 shotLocation = new Vector2(shooter.Position.X + shooter.Width / 2.6f, shooter.Position.Y);
            Projectile projectile = new Projectile(_projectileTexture, shotLocation, shooter, shooter.GameBounds);

            switch (projectileType)
            {
                case ProjectileType.Regular:
                    break;
            }
            EnemyProjectiles.Add(projectile);
        }



        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            foreach (var projectile in AllProjectiles)
            {
                projectile.Update(gameTime, gameObjects);
            }

            RemoveOutOfBoundsProjectiles(PlayerProjectiles);
            RemoveOutOfBoundsProjectiles(EnemyProjectiles);
        }

        private void RemoveOutOfBoundsProjectiles(IList<Projectile> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (!projectiles[i].GameBounds.Contains(projectiles[i].BoundingBox))
                {
                    projectiles.Remove(projectiles[i]);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in AllProjectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}
