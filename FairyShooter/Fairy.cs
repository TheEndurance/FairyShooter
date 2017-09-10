using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class Fairy : Sprite
    {
        private readonly Rectangle _screenBounds;

        public Fairy(Texture2D texture, Vector2 location, Rectangle screenBounds) : base(texture, location)
        {
            _screenBounds = screenBounds;

            Location.Y = screenBounds.Height - texture.Bounds.Height;
            Location.X = (float)screenBounds.Width / 2;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Velocity = new Vector2(-3f, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Velocity = new Vector2(3f, 0);
            }
            else
            {
                Velocity = new Vector2(0, 0);
            }

            base.Update(gameTime);
        }

        protected override void CheckBounds()
        {
            Location.X = MathHelper.Clamp(Location.X, 0, _screenBounds.Width - Texture.Width);
        }
    }

    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        public Vector2 Location;
        public Vector2 Velocity { get; protected set; }

        public int Height
        {
            get { return Texture.Bounds.Height; }
        }

        public int Width
        {
            get
            {
                return Texture.Bounds.Width;
            }

        }

        protected Sprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = location;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            Location += Velocity;
            CheckBounds();
        }

        protected abstract void CheckBounds();
    }
}