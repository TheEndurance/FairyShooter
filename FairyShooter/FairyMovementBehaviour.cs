using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class FairyMovementBehaviour : IMovementBehaviour
    {
        public void Move(Sprite sprite)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                sprite.Velocity = new Vector2(-3f, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                sprite.Velocity = new Vector2(3f, 0);
            }
            else
            {
                sprite.Velocity = new Vector2(0, 0);
            }
            
        }
    }
}
