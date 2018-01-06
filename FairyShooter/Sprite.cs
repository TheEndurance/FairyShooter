using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        public Vector2 Position;
        public Rectangle GameBounds { get; }
        public Vector2 Velocity { get; set; }
        public int Height => Texture.Bounds.Height/_rows;
        private int _columns;
        private int _rows;
        private int _totalFrames;
        private int currentFrame;
      
        private double _framesPerSecond;
        private double _timeSinceLastFrame;

        public int Width => Texture.Bounds.Width/_columns;

        public Rectangle BoundingBox => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        protected Sprite(Texture2D texture, Vector2 position, Rectangle gameBounds) : this (texture,position,gameBounds,1,1,1)
        {
            
        }

        protected Sprite(Texture2D texture, Vector2 position, Rectangle gameBounds, int rows, int columns,
            double framesPerSecond)
        {
            Texture = texture;
            Position = position;
            GameBounds = gameBounds;
            _rows = rows;
            _columns = columns;
            _framesPerSecond = framesPerSecond;
            _totalFrames = rows * columns;
        }


        public virtual void Draw(SpriteBatch spritebatch)
        {
            
            int imageWidth = Texture.Width / _columns;
            int imageHeight = Texture.Height / _rows;

            int currentRow = currentFrame / _columns;
            int currentColumn = currentFrame % _columns;

            Rectangle sourceRectangle = new Rectangle(imageWidth * currentColumn, imageWidth * currentRow, imageWidth,
                imageHeight);

            Rectangle destinationRectangle = new Rectangle((int) Position.X, (int) Position.Y, imageWidth, imageHeight);

            spritebatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }


        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CheckBounds();
            UpdateAnimation(gameTime);
        }

        protected abstract void CheckBounds();

        private void UpdateAnimation(GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.TotalSeconds;
            if (_timeSinceLastFrame > SecondsBetweenFrames())
            {
                currentFrame++;
                _timeSinceLastFrame = 0;
            }

            if (currentFrame == _totalFrames)
                currentFrame = 0;
        }

        private double SecondsBetweenFrames()
        {
            return 1 / _framesPerSecond;
        }
    }
}