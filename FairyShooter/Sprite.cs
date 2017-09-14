using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        public Vector2 Location;
        public Rectangle GameBounds { get; }
        public Vector2 Velocity { get; set; }

        public int Height => Texture.Bounds.Height;

        public int Width => Texture.Bounds.Width;

        public Rectangle BoundingBox => new Rectangle((int)Location.X, (int)Location.Y, Width, Height);

        protected Sprite(Texture2D texture, Vector2 location, Rectangle gameBounds)
        {
            Texture = texture;
            Location = location;
            GameBounds = gameBounds;
        }

        public abstract void Draw(SpriteBatch spritebatch);


        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location += Velocity;
            CheckBounds();
        }

        protected abstract void CheckBounds();
    }
}