using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class RegularProjectileMovement : IMovementBehaviour
    {
        public void Move(GameTime gameTime,Sprite sprite)
        {
            sprite.Position += (new Vector2(0, -600f) * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
