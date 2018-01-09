using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class StatusManager
    {
        private readonly SpriteFont _gameFont;
        private readonly Rectangle _gameBounds;
        private readonly EnemyManager _enemyManager;
        public int Score { get; set; }

        public StatusManager(SpriteFont gameFont,Rectangle gameBounds,EnemyManager enemyManager)
        {
            _gameFont = gameFont;
            _gameBounds = gameBounds;
            _enemyManager = enemyManager;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string scoreText = string.Format($"Score: {Score}");
            Vector2 scoreDimensions = _gameFont.MeasureString(scoreText);
            float scoreX = _gameBounds.Width - scoreDimensions.X - 5;
            float scoreY = scoreDimensions.Y + 5;

            spriteBatch.DrawString(_gameFont, scoreText, new Vector2(scoreX, scoreY), Color.Black);
        }

        public void UpdateScore()
        {
            int kills = _enemyManager.GetKillCount();
            Score += (kills * 25);
        }
    }
}