/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    /// <summary>
    /// Represents a specific fairy movement behaviour
    /// </summary>
    public class FairyMovementBehaviour : IMovementBehaviour
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="sprite"></param>
        public void Move(GameTime gameTime,Sprite sprite)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                sprite.Velocity= new Vector2(-300f, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                sprite.Velocity = new Vector2(300f, 0);
            }
            else
            {
                sprite.Velocity = new Vector2(sprite.Velocity.X * 0.9f, sprite.Velocity.Y * 0.9f);
            }
        }
    }
}
