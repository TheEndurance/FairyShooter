using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        public Vector2 Location;
        protected Rectangle GameBounds { get; }
        public Vector2 Velocity { get; protected set; }

        public int Height => Texture.Bounds.Height;

        public int Width => Texture.Bounds.Width;

        public Rectangle BoundingBox => new Rectangle((int)Location.X, (int)Location.Y, Width, Height);

        protected Sprite(Texture2D texture, Vector2 location, Rectangle gameBounds)
        {
            Texture = texture;
            Location = location;
            GameBounds = gameBounds;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location += Velocity;
            CheckBounds();
        }

        protected abstract void CheckBounds();
    }
}