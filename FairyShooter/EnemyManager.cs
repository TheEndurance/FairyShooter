using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class EnemyManager
    {
        private readonly Texture2D _texture;
        private readonly Rectangle _gameBounds;
        public TimeSpan SpawnInterval { get; set; }
        private TimeSpan? _lastSpawn;
        public IList<Enemy> Enemies { get; set; }

        public EnemyManager(Texture2D texture, Rectangle gameBounds)
        {
            Enemies = new List<Enemy>();
            _texture = texture;
            _gameBounds = gameBounds;
            SpawnInterval = TimeSpan.FromSeconds(1);

        }

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

        //TODO: Pass in Movement and Shooting Behaviours from LevelManager
        public void CreateEnemy()
        {
            Vector2 position = RandomPosition();
            Enemy enemy = new Enemy(_texture, position, _gameBounds,new EasyEnemyMovementBehaviour());
            Enemies.Add(enemy);
        }

        private Vector2 RandomPosition()
        {
            var random = new Random();
            var xPosition = random.Next(_gameBounds.Width - _texture.Width/2 + 1);
            return new Vector2(xPosition, -10);

        }
    }
}
