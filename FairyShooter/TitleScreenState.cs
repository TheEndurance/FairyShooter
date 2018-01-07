using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class TitleScreenState : GameState
    {

        public TitleScreenState(Game1 game) : base(game)
        {
        }

        public override void Update(GameTime gameTime,GameObjects gameObjects)
        {
            Game.TitleScreen.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Game.GameState = new PlayingState(Game);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.TitleScreen.Draw(spriteBatch);
        }
    }
}