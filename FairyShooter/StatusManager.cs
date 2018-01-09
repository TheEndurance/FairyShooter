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
    /// Manages the score for the game
    /// </summary>
    public class StatusManager
    {
        private readonly SpriteFont _gameFont;
        private readonly Rectangle _gameBounds;
        private readonly EnemyManager _enemyManager;
        public int Score { get; set; }

        /// <summary>
        /// Status manager constructor
        /// </summary>
        /// <param name="gameFont">SpriteFont</param>
        /// <param name="gameBounds">Game bounds</param>
        /// <param name="enemyManager">Manager for enemies</param>
        public StatusManager(SpriteFont gameFont,Rectangle gameBounds,EnemyManager enemyManager)
        {
            _gameFont = gameFont;
            _gameBounds = gameBounds;
            _enemyManager = enemyManager;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spriteBatch">Helper class for drawing game sprites and text.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            string scoreText = string.Format($"Score: {Score}");
            Vector2 scoreDimensions = _gameFont.MeasureString(scoreText);
            float scoreX = _gameBounds.Width - scoreDimensions.X - 2;
            float scoreY = 0;

            spriteBatch.DrawString(_gameFont, scoreText, new Vector2(scoreX, scoreY), Color.Black);
        }

        /// <summary>
        /// Updates the score after enemy is killed
        /// </summary>
        public void UpdateScore()
        {
            int kills = _enemyManager.GetKillCount();
            Score += (kills * 25);
        }
    }
}