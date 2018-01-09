/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          01/03/2017: Created
 *          
 */
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    /// <summary>
    /// Represents a game sprite
    /// </summary>
    public class Sprite
    {
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
        protected bool AnimationOncePlayed;
        protected readonly Texture2D Texture;
        private double _timeSinceLastFrame;
        private int _currentFrame;
        private int _direction = -1;


        /// <summary>
        /// Constructor for the sprite class for no animations
        /// </summary>
        /// <param name="texture">Sprite texture</param>
        /// <param name="position">Sprite position</param>
        /// <param name="gameBounds">Sprite game bounds</param>
        public Sprite(Texture2D texture, Vector2 position, Rectangle gameBounds) : this (texture,position,gameBounds,1,1,1)
        {
            
        }

        /// <summary>
        /// Constructor for the sprite class with animations
        /// </summary>
        /// <param name="texture">Sprite texture</param>
        /// <param name="position">Sprite position</param>
        /// <param name="gameBounds">Sprite game bounds</param>
        /// <param name="rows">Sprite sheet number of rows</param>
        /// <param name="columns">Sprite sheet number of columns</param>
        /// <param name="framesPerSecond">Frames per second for animation</param>
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="spritebatch">Helper class for drawing sprites and text</param>
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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="gameObjects">Provides the game objects</param>
        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Update(gameTime);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public virtual void Update(GameTime gameTime)
        {
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CheckBounds();
            UpdateAnimation(gameTime);
        }

        /// <summary>
        /// Checks to see if sprite is outside game bounds
        /// </summary>
        protected virtual void CheckBounds()
        {
            Position.X = MathHelper.Clamp(Position.X, 0, GameBounds.Width - Width);
        }

        /// <summary>
        /// Updates the animation cycle
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        private void UpdateAnimation(GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.TotalSeconds;
            if (_timeSinceLastFrame > SecondsBetweenFrames())
            {
                _currentFrame++;
                _timeSinceLastFrame = 0;
            }

            if (_currentFrame == TotalFrames)
            {
                _currentFrame = 0;
                AnimationOncePlayed = true;
            }
        }

        /// <summary>
        /// Helper method to determine number of seconds between frames
        /// </summary>
        /// <returns>Integer representing seconds between frames</returns>
        private double SecondsBetweenFrames()
        {
            return 1 / FramesPerSecond;
        }
    }
}