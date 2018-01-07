using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    public class Fairy : Sprite
    {
       
        public IMovementBehaviour MovementBehaviour { get; set; }
        public IShootingBehaviour ShootingBehaviour { get; set; }

        public Fairy(Texture2D texture, Vector2 position, Rectangle gameBounds) : base(texture, position, gameBounds, 1,4,14)
        {
            Position.Y = GameBounds.Height - Height;
            Position.X = (float)GameBounds.Width / 2;
            MovementBehaviour = new FairyMovementBehaviour();
            ShootingBehaviour = new FairyNormalShootingBehaviour();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {

            MovementBehaviour.Move(gameTime,this);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ShootingBehaviour.Shoot(gameTime, gameObjects.ProjectileManager, this);
            }

            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
            Position.X = MathHelper.Clamp(Position.X, 0, GameBounds.Width - Width);
        }

        public void Hit()
        {
            IsDead = true;
        }

       
    }
}