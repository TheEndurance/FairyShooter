/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    /// <summary>
    /// The main player sprite
    /// </summary>
    public class Fairy : Sprite
    {
       
        public IMovementBehaviour MovementBehaviour { get; set; }
        public IShootingBehaviour ShootingBehaviour { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Constructor for the fairy sprite
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="gameBounds"></param>
        public Fairy(Texture2D texture, Vector2 position, Rectangle gameBounds) : base(texture, position, gameBounds, 1,4,14)
        {
            Position.Y = GameBounds.Height - Height;
            Position.X = (float)GameBounds.Width / 2;
            MovementBehaviour = new FairyMovementBehaviour();
            ShootingBehaviour = new FairyNormalShootingBehaviour();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="spritebatch"></param>
        public override void Draw(SpriteBatch spritebatch)
        {
            if (!IsDead)
            {
                base.Draw(spritebatch);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="gameObjects"></param>
        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {

            MovementBehaviour.Move(gameTime,this);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ShootingBehaviour.Shoot(gameTime, gameObjects.ProjectileManager, this);
            }

            base.Update(gameTime, gameObjects);
        }

        /// <summary>
        /// Sets the fairy to dead state
        /// </summary>
        public void Hit()
        {
            IsDead = true;
        }

       
    }
}