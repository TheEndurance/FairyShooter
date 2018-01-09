using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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