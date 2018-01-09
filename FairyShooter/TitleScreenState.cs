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
    /// Game state for when the game is at the title screen
    /// </summary>
    public class TitleScreenState : GameState
    {

        /// <summary>
        /// Constructor for the title screen state
        /// </summary>
        /// <param name="game">Main game</param>
        public TitleScreenState(Game1 game) : base(game)
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="gameObjects">Provides access to game objects</param>
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing sprites and text</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.TitleScreen.Draw(spriteBatch);
        }
    }
}