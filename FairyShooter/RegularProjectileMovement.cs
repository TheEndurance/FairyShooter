/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    /// <summary>
    /// A regular projectile movement behaviour
    /// </summary>
    public class RegularProjectileMovement : IMovementBehaviour
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="sprite"></param>
        public void Move(GameTime gameTime,Sprite sprite)
        {
            sprite.Velocity = new Vector2(0, 600f * sprite.Direction);
        }
    }
}
