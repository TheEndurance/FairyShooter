using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FairyShooter
{
    public class Fairy : Sprite
    {
        private readonly Rectangle _screenBounds;

        public Fairy(Texture2D texture, Vector2 location,Rectangle screenBounds) : base(texture, location)
        {
            _screenBounds = screenBounds;

            location.Y = screenBounds.Height - texture.Bounds.Height;
            location.X = (float)screenBounds.Width / 2;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Velocity.X = -3f;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Velocity.X = 3f;

            base.Update(gameTime);
        }

    }

    public class Sprite
    {
        protected readonly Texture2D Texture;
        public Vector2 Location;
        protected Vector2 Velocity;

        public int Height
        {
            get { return Texture.Bounds.Height; }
        }

        public int Width {
            get
            {
                return Texture.Bounds.Width;
            }

       }

        public Sprite(Texture2D texture, Vector2 location)
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
        }
    }
}