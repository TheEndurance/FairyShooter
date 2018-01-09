using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class GameOverState : PlayingState
    {
        private TimeSpan gameOverDuration = TimeSpan.FromSeconds(3);
        private double elapsedTime;
        public GameOverState(Game1 game) : base(game)
        {
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            base.Update(gameTime, gameObjects);
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
           
            Game.GameOverScreen.Update(gameTime);
            if (elapsedTime >= gameOverDuration.TotalSeconds)
            {
                Game.ResetGame();
                Game.GameState = new TitleScreenState(Game);
            }
          
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Game.GameOverScreen.Draw(spriteBatch);
        }
    }
}