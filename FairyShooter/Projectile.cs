/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    /// <summary>
    /// Projectile sprite
    /// </summary>
    public class Projectile : Sprite
    {
        public Sprite Shooter { get; private set; }
        public IMovementBehaviour MovementBehaviour { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Constructor for the projectile sprite
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="shooter">The sprite that is shooting</param>
        /// <param name="gameBounds"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="framePerSecond"></param>
        public Projectile(Texture2D texture, Vector2 position, Sprite shooter, Rectangle gameBounds, int row = 1, int column = 1, int framePerSecond = 1) : base(texture, position, gameBounds, row, column, framePerSecond)
        {
            Shooter = shooter;
            Direction = shooter.Direction;
            MovementBehaviour = new RegularProjectileMovement();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="gameObjects"></param>
        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            MovementBehaviour.Move(gameTime, this);
            base.Update(gameTime, gameObjects);
        }

    }
}