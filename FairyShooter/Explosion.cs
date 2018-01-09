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
    /// Sprite representing an explosion
    /// </summary>
    public class Explosion : Sprite
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructor for the explosion sprite
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="gameBounds"></param>
        public Explosion(Texture2D texture, Vector2 position, Rectangle gameBounds) : base(texture, position, gameBounds, 5, 8, 30)
        {

        }

        /// <summary>
        /// Determines if animation for the sprite finished 1 cycle
        /// </summary>
        /// <returns>True if the animation completed 1 cycle</returns>
        public bool AnimationComplete()
        {
            return AnimationOncePlayed;
        }
    }
}
