/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    /// <summary>
    /// Game state for when game is paused
    /// </summary>
    public class GamePausedState : GameState
    {
        /// <summary>
        /// Constructor for the game paused state
        /// </summary>
        /// <param name="game">Main game</param>
        public GamePausedState(Game1 game) : base(game)
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="gameObjects">Provides access to game objects</param>
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing sprites and text</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.PausedScreen.Draw(spriteBatch);
        }
    }
}