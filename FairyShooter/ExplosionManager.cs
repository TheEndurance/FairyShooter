using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class ExplosionManager
    {
        private readonly Texture2D _explosionTexture;
        private readonly Rectangle _gameBounds;
        private IList<Explosion> _explosions = new List<Explosion>();


        public ExplosionManager(Texture2D explosionTexture,Rectangle gameBounds)
        {
            _explosionTexture = explosionTexture;
            _gameBounds = gameBounds;
        }

        public void CreateExplosion(Sprite sprite)
        {
            Vector2 centerOfSprite = new Vector2(sprite.Position.X + (sprite.Width / 2),
                sprite.Position.Y + (sprite.Height / 2));
            Explosion explosion = new Explosion(_explosionTexture, centerOfSprite, _gameBounds);
            explosion.Position -= new Vector2(explosion.Width / 2, explosion.Height / 2);
            _explosions.Add(explosion);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Explosion explosion in _explosions)
            {
                explosion.Draw(spriteBatch);
            }
            
        }

        public void Update(GameTime gameTime,GameObjects gameObjects)
        {
            for (var index = 0; index < _explosions.Count; index++)
            {
  
                _explosions[index].Update(gameTime, gameObjects);
                if (_explosions[index].AnimationComplete())
                {
                    _explosions.Remove(_explosions[index]);
                }
            }
        }
    }
}
