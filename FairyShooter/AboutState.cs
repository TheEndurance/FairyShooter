using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class AboutState : GameState
    {
        public AboutState(Game1 game) : base (game)
        {
            
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Game.AboutScreen.Update(gameTime);
            if (Game.CurrentKeyboardState.IsKeyDown(Keys.Back) && !Game.PreviousKeyboardState.IsKeyDown(Keys.Back))
            {
                Game.GameState = new TitleScreenState(Game);
            }
            else if (Game.CurrentKeyboardState.IsKeyDown(Keys.Escape) && !Game.PreviousKeyboardState.IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.AboutScreen.Draw(spriteBatch);
        }
    }
}