using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class RegularProjectileMovement : IMovementBehaviour
    {
        public void Move(GameTime gameTime,Sprite sprite)
        {
            sprite.Velocity = new Vector2(0, 600f * sprite.Direction);
        }
    }
}
