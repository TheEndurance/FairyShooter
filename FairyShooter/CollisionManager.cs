/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    /// <summary>
    /// Manages game collisions
    /// </summary>
    public class CollisionManager
    {
        private readonly GameObjects _gameObjects;

        /// <summary>
        /// Constructor for collision manager
        /// </summary>
        /// <param name="gameObjects"></param>
        public CollisionManager(GameObjects gameObjects)
        {
            _gameObjects = gameObjects;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            CheckCollisions();
        }

        /// <summary>
        /// Checks for collisions
        /// </summary>
        private void CheckCollisions()
        {
            CheckShotToPlayer();
            CheckShotToEnemy();
        }

        /// <summary>
        /// Checks for shots that hit player
        /// </summary>
        private void CheckShotToPlayer()
        {
            for (var i = 0; i < _gameObjects.ProjectileManager.EnemyProjectiles.Count; i++)
            {
                Projectile projectile = _gameObjects.ProjectileManager.EnemyProjectiles[i];
                Fairy fairy = _gameObjects.Fairy;
                if (projectile.BoundingBox.Intersects(fairy.BoundingBox) 
                    && !fairy.IsDead
                    && projectile.Shooter is Enemy)
                {
                    fairy.Hit();
                    if (fairy.IsDead)
                    {
                        _gameObjects.ExplosionManager.CreateExplosion(fairy);
                    }
                    _gameObjects.ProjectileManager.RemoveEnemyProjectile(projectile);
                }
            }
        }

        /// <summary>
        /// Checks for shots that hit enemy
        /// </summary>
        private void CheckShotToEnemy()
        {
            for (var i = 0; i < _gameObjects.ProjectileManager.PlayerProjectiles.Count; i++) {
                Projectile projectile = _gameObjects.ProjectileManager.PlayerProjectiles[i];


                for (var j = 0; j < _gameObjects.EnemyManager.Enemies.Count; j++)
                {
                    Enemy enemy = _gameObjects.EnemyManager.Enemies[j];
                    if (projectile.BoundingBox.Intersects(enemy.BoundingBox)
                        && !enemy.IsDead
                        && projectile.Shooter is Fairy)
                    {
                        enemy.Hit();
                        _gameObjects.ProjectileManager.RemovePlayerProjectile(projectile);
                        if (enemy.IsDead)
                        {
                            _gameObjects.ExplosionManager.CreateExplosion(enemy);
                        }
                    }
                }
            }
        }
    }
}
