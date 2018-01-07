using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public abstract class GameState : Game
    {
        protected readonly Game1 Game;

        protected GameState(Game1 game)
        {
            this.Game = game;
        }

        public abstract void Update(GameTime gameTime,GameObjects gameObjects);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}