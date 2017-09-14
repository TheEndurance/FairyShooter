using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    public class Fairy : Sprite
    {
        private readonly ProjectileManager _projectileManager;
       
        public IMovementBehaviour MovementBehaviour { get; set; }
        public IShootingBehaviour ShootingBehaviour { get; set; }

        public Fairy(Texture2D texture, Vector2 location, Rectangle screenBounds, ProjectileManager projectileManager) : base(texture, location, screenBounds)
        {
            _projectileManager = projectileManager;
            Location.Y = GameBounds.Height - Height;
            Location.X = (float)GameBounds.Width / 2;
            MovementBehaviour = new FairyMovementBehaviour();
            ShootingBehaviour = new NormalShootingBehaviour();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Location, Color.White);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {

            MovementBehaviour.Move(this);
            ShootingBehaviour.Shoot(gameTime,_projectileManager,this);

            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
            Location.X = MathHelper.Clamp(Location.X, 0, GameBounds.Width - Width);
        }
    }
}