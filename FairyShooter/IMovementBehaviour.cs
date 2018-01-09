/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public interface IMovementBehaviour
    {
        /// <summary>
        /// Moves the sprite according to the behaviour defined
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="sprite">The sprite to execute the behaviour on</param>
        void Move(GameTime gameTime,Sprite sprite);
    }
}
