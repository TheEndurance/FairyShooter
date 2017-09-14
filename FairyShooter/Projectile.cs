using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class Projectile : Sprite
    {
        private bool alive;
        public IMovementBehaviour MovementBehaviour { get; set; }
        public Projectile(Texture2D texture, Vector2 location, Rectangle screenBounds,IMovementBehaviour movementBehaviour) : base(texture, location, screenBounds)
        {
            alive = true;
            MovementBehaviour = movementBehaviour;
        }

        protected override void CheckBounds()
        {

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Location, Color.White);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (alive)
            {
                MovementBehaviour.Move(this);
                if (Location.Y < 0)
                {
                    alive = false;
                }
                //add collision with monsters
            }
            else
            {
                gameObjects.ProjectileManager.Projectiles.Remove(this);
            }
            base.Update(gameTime, gameObjects);
        }

    }
}