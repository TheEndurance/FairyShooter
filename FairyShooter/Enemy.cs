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
    /// An enemy sprite
    /// </summary>
    public class Enemy : Sprite
    {

        public IMovementBehaviour MovementBehaviour { get; set; }
        public IShootingBehaviour ShootingBehaviour { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Enemy class constructor
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="screenBounds"></param>
        /// <param name="movementBehaviour">Represents the movement behaviour for the enemy</param>
        public Enemy(Texture2D texture, Vector2 position, Rectangle screenBounds, IMovementBehaviour movementBehaviour) : base(texture, position, screenBounds, 1, 3, 10)
        {
            MovementBehaviour = movementBehaviour;
            ShootingBehaviour = new SlowEnemyShootingBehaviour();
            Direction = 1;
        }


        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="gameObjects"></param>
        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            MovementBehaviour.Move(gameTime, this);
            ShootingBehaviour.Shoot(gameTime, gameObjects.ProjectileManager, this);
            base.Update(gameTime, gameObjects);
        }

        /// <summary>
        /// Sets the enemy to dead state
        /// </summary>
        public void Hit()
        {
            IsDead = true;
        }
    }
}
