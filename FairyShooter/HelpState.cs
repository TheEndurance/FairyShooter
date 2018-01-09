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
    /// Game state that shows game information
    /// </summary>
    public class HelpState : GameState
    {
        /// <summary>
        /// Constructor for the help state
        /// </summary>
        /// <param name="game">Main game</param>
        public HelpState(Game1 game) : base(game)
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing sprites and text</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.HelpScreen.Draw(spriteBatch);
        }
    }
}