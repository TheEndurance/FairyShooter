/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    /// <summary>
    /// Abstract class for game states
    /// </summary>
    public abstract class GameState : Game
    {
        protected readonly Game1 Game;

        /// <summary>
        /// Constructor for game state
        /// </summary>
        /// <param name="game"></param>
        protected GameState(Game1 game)
        {
            this.Game = game;
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="gameObjects">Provides access to game objects</param>
        public abstract void Update(GameTime gameTime,GameObjects gameObjects);

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing sprites and text</param>
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}