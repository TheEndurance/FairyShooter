using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class PlayingState : GameState
    {
        public PlayingState(Game1 game) : base(game)
        {
            
        }

        public override void Update(GameTime gameTime,GameObjects gameObjects)
        {
            Game.Fairy.Update(gameTime, Game.GameObjects);
            Game.EnemyManager.Update(gameTime, Game.GameObjects);
            Game.ProjectileManager.Update(gameTime, Game.GameObjects);
            Game.ExplosionManager.Update(gameTime, Game.GameObjects);
            Game.CollisionManager.Update(gameTime);
            if (Game.Fairy.IsDead)
            {
                Game.GameState = new GameOverState(Game);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.Fairy.Draw(spriteBatch);
            Game.ProjectileManager.Draw(spriteBatch);
            Game.EnemyManager.Draw(spriteBatch);
            Game.ExplosionManager.Draw(spriteBatch);
        }
    }
}