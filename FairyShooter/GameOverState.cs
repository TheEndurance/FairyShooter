using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class GameOverState : GameState
    {
        private TimeSpan gameOverDuration;
        private double elapsedTime;
        public GameOverState(Game1 game) : base(game)
        {
            gameOverDuration = TimeSpan.FromSeconds(2);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            Game.GameOverScreen.Update(gameTime);
            if (elapsedTime >= gameOverDuration.TotalSeconds)
            {
                Game.GameState = new TitleScreenState(Game);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            Game.GameOverScreen.Draw(spriteBatch);
        }
    }
}