using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace FairyShooter
{
    public class ProjectileManager
    {
        public IList<Projectile> PlayerProjectiles = new List<Projectile>();
        public IList<Projectile> EnemyProjectiles = new List<Projectile>();
        public IEnumerable<Projectile> AllProjectiles
        {
            get { return EnemyProjectiles.Union(PlayerProjectiles); }
        }

        private Texture2D playerProjectileTexture;
        private Texture2D enemyProjectileTexture;
        private readonly Texture2D _projectileTexture;
        private readonly SoundManager _soundManager;

        public ProjectileManager(ContentManager content,SoundManager soundManager)
        {
            enemyProjectileTexture = content.Load<Texture2D>("enemyprojectile");
            playerProjectileTexture = content.Load<Texture2D>("purpleprojectile");
            _soundManager = soundManager;
        }

        public void Shoot(ProjectileType projectileType, Sprite shooter)
        {
            Vector2 shotLocation = new Vector2(shooter.Position.X + shooter.Width / 2.6f, shooter.Position.Y);
            Projectile projectile = new Projectile(playerProjectileTexture, shotLocation, shooter, shooter.GameBounds,4,1,14);
            SetProjectileMovementBehaviour(projectileType, projectile);
            PlayerProjectiles.Add(projectile);

            _soundManager.PlayLaserEffect();
        }

        public void EnemyShoot(ProjectileType projectileType, Sprite shooter)
        {

            Vector2 shotLocation = new Vector2(shooter.Position.X + shooter.Width / 2.6f, shooter.Position.Y);
            Projectile projectile = new Projectile(enemyProjectileTexture, shotLocation, shooter, shooter.GameBounds,3,1,14);
            SetProjectileMovementBehaviour(projectileType, projectile);
            EnemyProjectiles.Add(projectile);
        }

        public void RemovePlayerProjectile(Projectile projectile)
        {
            PlayerProjectiles.Remove(projectile);
        }

        public void RemoveEnemyProjectile(Projectile projectile)
        {
            EnemyProjectiles.Remove(projectile);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in AllProjectiles)
            {
                projectile.Draw(spriteBatch);
            }
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


        private void SetProjectileMovementBehaviour(ProjectileType projectileType,Projectile projectile)
        {
            IMovementBehaviour projectileMovementBehaviour;

            switch (projectileType)
            {
                case ProjectileType.Slow:
                    projectileMovementBehaviour = new SlowProjectileMovement();
                    break;
                default:
                    return;
            }
            projectile.MovementBehaviour = projectileMovementBehaviour;
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



    }
}
