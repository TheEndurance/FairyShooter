using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public interface IMovementBehaviour
    {
        void Move(GameTime gameTime,Sprite sprite);
    }
}
