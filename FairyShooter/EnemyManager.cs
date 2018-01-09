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
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    /// <summary>
    /// Manages enemies
    /// </summary>
    public class EnemyManager
    {
        
        public TimeSpan SpawnInterval { get; set; }
        public IList<Enemy> Enemies { get; set; }
        private readonly Texture2D _texture;
        private readonly Rectangle _gameBounds;
        private TimeSpan? _lastSpawn;

        /// <summary>
        /// constructor for the enemy manager
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="gameBounds"></param>
        public EnemyManager(Texture2D texture, Rectangle gameBounds)
        {
            Enemies = new List<Enemy>();
            _texture = texture;
            _gameBounds = gameBounds;
            SpawnInterval = TimeSpan.FromSeconds(1);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing game sprites and text.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (!enemy.IsDead)
                {
                    enemy.Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="gameObjects">Provides access to game objects</param>
        public void Update(GameTime gameTime,GameObjects gameObjects)
        {
            if (_lastSpawn == null || gameTime.TotalGameTime - _lastSpawn >= SpawnInterval)
            {
                CreateEnemy();
                _lastSpawn = gameTime.TotalGameTime;

            }
            for (var index = 0; index < Enemies.Count; index++)
            {

                if (!Enemies[index].IsDead)
                {
                    Enemies[index].Update(gameTime, gameObjects);
                }
                else
                {
                    Enemies.Remove(Enemies[index]);
                }
            }
        }

        /// <summary>
        /// Creates an enemy
        /// </summary>
        public void CreateEnemy()
        {
            Vector2 position = RandomPosition();
            Enemy enemy = new Enemy(_texture, position, _gameBounds,new EasyEnemyMovementBehaviour());
            Enemies.Add(enemy);
        }

        /// <summary>
        /// Creates a random position
        /// </summary>
        /// <returns>A random Vector2 position</returns>
        private Vector2 RandomPosition()
        {
            var random = new Random();
            var xPosition = random.Next(_gameBounds.Width - _texture.Width/2 + 1);
            return new Vector2(xPosition, -10);

        }

        /// <summary>
        /// Determines how many enemies killed in the current update cycle
        /// </summary>
        /// <returns>Kill count</returns>
        public int GetKillCount()
        {
            return Enemies.Count(e => e.IsDead);
        }
    }
}
