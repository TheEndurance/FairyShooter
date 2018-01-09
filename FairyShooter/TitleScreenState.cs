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
            } else if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                Game.GameState = new HelpState(Game);
            } else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Game.GameState = new AboutState(Game);
            } else if (Game.CurrentKeyboardState.IsKeyDown(Keys.Escape) && !Game.PreviousKeyboardState.IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.TitleScreen.Draw(spriteBatch);
        }
    }
}