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
    /// Game state for when the game is playing
    /// </summary>
    public class PlayingState : GameState
    {
        /// <summary>
        /// Constructor for the playing state
        /// </summary>
        /// <param name="game"></param>
        public PlayingState(Game1 game) : base(game)
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
            Game.Fairy.Update(gameTime, Game.GameObjects);
            Game.EnemyManager.Update(gameTime, Game.GameObjects);
            Game.ProjectileManager.Update(gameTime, Game.GameObjects);
            Game.ExplosionManager.Update(gameTime, Game.GameObjects);
            Game.CollisionManager.Update(gameTime);
            Game.GameStatusManager.UpdateScore();
            
            if (Game.CurrentKeyboardState.IsKeyDown(Keys.P) && !Game.PreviousKeyboardState.IsKeyDown(Keys.P))
            {
                Game.GameState = new GamePausedState(Game);
            }
            if (Game.Fairy.IsDead && Game.GameState.GetType()!=typeof(GameOverState))
            {
                Game.GameState = new GameOverState(Game);
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
            Game.Fairy.Draw(spriteBatch);
            Game.ProjectileManager.Draw(spriteBatch);
            Game.EnemyManager.Draw(spriteBatch);
            Game.ExplosionManager.Draw(spriteBatch);
            Game.GameStatusManager.Draw(spriteBatch);
        }


    }
}