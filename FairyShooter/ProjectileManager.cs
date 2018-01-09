/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace FairyShooter
{
    /// <summary>
    /// Creates projectiles
    /// </summary>
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

        /// <summary>
        /// Constructor for projectile manager
        /// </summary>
        /// <param name="content">Game content</param>
        /// <param name="soundManager">Sound manager for game</param>
        public ProjectileManager(ContentManager content,SoundManager soundManager)
        {
            enemyProjectileTexture = content.Load<Texture2D>("enemyprojectile");
            playerProjectileTexture = content.Load<Texture2D>("purpleprojectile");
            _soundManager = soundManager;
        }

        /// <summary>
        /// Shoots a projectile for player
        /// </summary>
        /// <param name="projectileType">The type of the projectile</param>
        /// <param name="shooter">The sprite that is shooting</param>
        public void Shoot(ProjectileType projectileType, Sprite shooter)
        {
            Vector2 shotLocation = new Vector2(shooter.Position.X + shooter.Width / 2.6f, shooter.Position.Y);
            Projectile projectile = new Projectile(playerProjectileTexture, shotLocation, shooter, shooter.GameBounds,4,1,14);
            SetProjectileMovementBehaviour(projectileType, projectile);
            PlayerProjectiles.Add(projectile);
            _soundManager.PlayLaserEffect();
        }

        /// <summary>
        /// Shoots a projectile for enemy
        /// </summary>
        /// <param name="projectileType">The type of the projectile</param>
        /// <param name="shooter">The sprite that is shooting</param>
        public void EnemyShoot(ProjectileType projectileType, Sprite shooter)
        {
            Vector2 shotLocation = new Vector2(shooter.Position.X + shooter.Width / 2.6f, shooter.Position.Y);
            Projectile projectile = new Projectile(enemyProjectileTexture, shotLocation, shooter, shooter.GameBounds,3,1,14);
            SetProjectileMovementBehaviour(projectileType, projectile);
            EnemyProjectiles.Add(projectile);
        }

        /// <summary>
        /// Removes a player projectile
        /// </summary>
        /// <param name="projectile">The projectile that will be removed</param>
        public void RemovePlayerProjectile(Projectile projectile)
        {
            PlayerProjectiles.Remove(projectile);
        }

        /// <summary>
        /// Removes a enemy projectile
        /// </summary>
        /// <param name="projectile">The projectile that will be removed</param>
        public void RemoveEnemyProjectile(Projectile projectile)
        {
            EnemyProjectiles.Remove(projectile);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing game sprites and text.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in AllProjectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="gameObjects">Provides access to game objects</param>
        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            foreach (var projectile in AllProjectiles)
            {
                projectile.Update(gameTime, gameObjects);
            }
            RemoveOutOfBoundsProjectiles(PlayerProjectiles);
            RemoveOutOfBoundsProjectiles(EnemyProjectiles);
        }

        /// <summary>
        /// Sets the movement behaviour of the projectile
        /// </summary>
        /// <param name="projectileType">The type of the projectile</param>
        /// <param name="projectile">Projectile sprite</param>
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

        /// <summary>
        /// Deletes projectiles that are out of bounds
        /// </summary>
        /// <param name="projectiles">Projectile sprite</param>
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
