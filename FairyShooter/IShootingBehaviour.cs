/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using System;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    /// <summary>
    /// Represents a specific shooting behaviour
    /// </summary>
    public interface IShootingBehaviour
    {
        /// <summary>
        /// Shoots according to the defined shooting behaviour
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="projectileManager">Creates projectiles</param>
        /// <param name="sprite">The sprite to execute the behaviour on</param>
        void Shoot(GameTime gameTime, ProjectileManager projectileManager,Sprite sprite);
    }
}
