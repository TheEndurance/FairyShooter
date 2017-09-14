using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class Projectile : Sprite
    {
        private bool alive;
        public Projectile(Texture2D texture, Vector2 location, Rectangle screenBounds) : base(texture, location, screenBounds)
        {
            alive = true;
        }

        protected override void CheckBounds()
        {

        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (alive)
            {
                Velocity = new Vector2(0, -3f);
                if (Location.Y < 0)
                {
                    alive = false;
                }
                //add collision with monsters
            }
            else
            {
                gameObjects.Projectiles.Remove(this);
            }
            base.Update(gameTime, gameObjects);
        }

    }
}