using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class RegularProjectileMovement : IMovementBehaviour
    {
        public void Move(Sprite sprite)
        {
            sprite.Velocity = new Vector2(0, -3f);
        }
    }
}
