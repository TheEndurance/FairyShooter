using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class SlowProjectileMovement : IMovementBehaviour
    {
        public void Move(GameTime gameTime, Sprite sprite)
        {
            sprite.Velocity = new Vector2(0, 300f * sprite.Direction);
        }
    }
}
