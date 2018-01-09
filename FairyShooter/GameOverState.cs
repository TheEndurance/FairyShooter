/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    /// <summary>
    /// Game state for when the game ends
    /// </summary>
    public class GameOverState : PlayingState
    {
        private TimeSpan gameOverDuration = TimeSpan.FromSeconds(3);
        private double elapsedTime;

        /// <summary>
        /// Constructor for game over state
        /// </summary>
        /// <param name="game">Main game</param>
        public GameOverState(Game1 game) : base(game)
        {
            Game.SoundManager.StopPlayingBackgroundMusic();
            Game.SoundManager.PlayGameOverEffect();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="gameObjects">Provides access to game objects</param>
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing sprites and text</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Game.GameOverScreen.Draw(spriteBatch);
        }
    }
}