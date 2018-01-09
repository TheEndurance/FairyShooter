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
    /// Holds the behaviour for easy enemy movement
    /// </summary>
    public class EasyEnemyMovementBehaviour : IMovementBehaviour
    {
        public void Move(GameTime gameTime, Sprite sprite)
        {
            sprite.Velocity = new Vector2(0, 50f);
        }
    }
}
