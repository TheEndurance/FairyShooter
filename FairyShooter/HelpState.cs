using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class HelpState : GameState
    {
        public HelpState(Game1 game) : base(game)
        {

        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Game.HelpScreen.Update(gameTime);
            if (Game.CurrentKeyboardState.IsKeyDown(Keys.Back) && !Game.PreviousKeyboardState.IsKeyDown(Keys.Back))
            {
                Game.GameState = new TitleScreenState(Game);
            } else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Game.GameState = new AboutState(Game);
            }
            else if (Game.CurrentKeyboardState.IsKeyDown(Keys.Escape) && !Game.PreviousKeyboardState.IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.HelpScreen.Draw(spriteBatch);
        }
    }
}