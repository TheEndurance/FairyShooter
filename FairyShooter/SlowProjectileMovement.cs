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

namespace FairyShooter
{
    /// <summary>
    /// Slow projectile movement behaviour
    /// </summary>
    public class SlowProjectileMovement : IMovementBehaviour
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="sprite"></param>
        public void Move(GameTime gameTime, Sprite sprite)
        {
            sprite.Velocity = new Vector2(0, 300f * sprite.Direction);
        }
    }
}
