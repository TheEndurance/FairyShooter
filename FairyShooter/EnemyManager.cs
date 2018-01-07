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
        public IList<Enemy> Enemies { get; set; }

        public EnemyManager(Texture2D texture, Rectangle gameBounds)
        {
            Enemies = new List<Enemy>();
            _texture = texture;
            _gameBounds = gameBounds;
            CreateEnemy();
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
            foreach (Enemy enemy in Enemies)
            {
                enemy.Update(gameTime, gameObjects);
            }
        }

        public void CreateEnemy()
        {
            Vector2 position = RandomPosition();
            Enemy enemy = new Enemy(_texture, position, _gameBounds,new EasyEnemyMovementBehaviour());
            Enemies.Add(enemy);
        }

        private Vector2 RandomPosition()
        {
            var random = new Random();
            var xPosition = random.Next(_gameBounds.Width - _texture.Width + 1);
            return new Vector2(xPosition, 20);

        }
    }
}
