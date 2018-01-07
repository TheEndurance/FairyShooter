using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;

        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector2 Position;
        public Rectangle GameBounds { get; }
        public Vector2 Velocity { get; set; }
        public int Height => Texture.Bounds.Height/Rows;
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int TotalFrames { get; set; }
        public double FramesPerSecond { get; set; }
        public int Width => Texture.Bounds.Width / Columns;
        public Rectangle BoundingBox => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        public bool IsDead { get; set; }

        private double _timeSinceLastFrame;
        private int _currentFrame;
        private int _direction = -1;


        public Sprite(Texture2D texture, Vector2 position, Rectangle gameBounds) : this (texture,position,gameBounds,1,1,1)
        {
            
        }

        public Sprite(Texture2D texture, Vector2 position, Rectangle gameBounds, int rows, int columns,
            double framesPerSecond)
        {
            Texture = texture;
            Position = position;
            GameBounds = gameBounds;
            Rows = rows;
            Columns = columns;
            FramesPerSecond = framesPerSecond;
            TotalFrames = rows * columns;
        }


        public virtual void Draw(SpriteBatch spritebatch)
        {
            
            int imageWidth = Texture.Width / Columns;
            int imageHeight = Texture.Height / Rows;

            int currentRow = _currentFrame / Columns;
            int currentColumn = _currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(imageWidth * currentColumn, imageHeight * currentRow, imageWidth,
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
                _currentFrame++;
                _timeSinceLastFrame = 0;
            }

            if (_currentFrame == TotalFrames)
                _currentFrame = 0;
        }

        private double SecondsBetweenFrames()
        {
            return 1 / FramesPerSecond;
        }
    }
}