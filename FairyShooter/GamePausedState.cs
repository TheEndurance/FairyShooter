using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class GamePausedState : GameState
    {
        public GamePausedState(Game1 game) : base(game)
        {
            
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Game.PausedScreen.Update(gameTime);
            if (Game.CurrentKeyboardState.IsKeyDown(Keys.P) && !Game.PreviousKeyboardState.IsKeyDown(Keys.P))
            {
                Game.GameState = new PlayingState(Game);
            }
            else if (Game.CurrentKeyboardState.IsKeyDown(Keys.Escape) && !Game.PreviousKeyboardState.IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.PausedScreen.Draw(spriteBatch);
        }
    }
}