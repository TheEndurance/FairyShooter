using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class FairyMovementBehaviour : IMovementBehaviour
    {
        public void Move(GameTime gameTime,Sprite sprite)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                sprite.Velocity= new Vector2(-300f, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                sprite.Velocity = new Vector2(300f, 0);
            }
            else
            {
                sprite.Velocity = new Vector2(sprite.Velocity.X * 0.9f, sprite.Velocity.Y * 0.9f);
            }
        }
    }
}
