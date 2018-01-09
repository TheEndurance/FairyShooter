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
    /// Manages game explosions
    /// </summary>
    public class ExplosionManager
    {
        private readonly Texture2D _explosionTexture;
        private readonly Rectangle _gameBounds;
        private readonly SoundManager _soundManager;
        private IList<Explosion> _explosions = new List<Explosion>();

        /// <summary>
        /// Constructor for the explosion manager
        /// </summary>
        /// <param name="explosionTexture">The explosion texture</param>
        /// <param name="gameBounds">Game bounds</param>
        /// <param name="soundManager">Sound manager</param>
        public ExplosionManager(Texture2D explosionTexture,Rectangle gameBounds,SoundManager soundManager)
        {
            _explosionTexture = explosionTexture;
            _gameBounds = gameBounds;
            _soundManager = soundManager;
        }

        /// <summary>
        /// Creates an explosion
        /// </summary>
        /// <param name="sprite">The sprite that died</param>
        public void CreateExplosion(Sprite sprite)
        {
            Vector2 centerOfSprite = new Vector2(sprite.Position.X + (sprite.Width / 2),
                sprite.Position.Y + (sprite.Height / 2));
            Explosion explosion = new Explosion(_explosionTexture, centerOfSprite, _gameBounds);
            explosion.Position -= new Vector2(explosion.Width / 2, explosion.Height / 2);
            _explosions.Add(explosion);

            _soundManager.PlayBoomEffect();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing game sprites and text.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Explosion explosion in _explosions)
            {
                explosion.Draw(spriteBatch);
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
