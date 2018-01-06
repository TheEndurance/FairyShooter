using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class Enemy : Sprite
    {

        public bool Alive { get; set; }
        public IMovementBehaviour MovementBehaviour { get; set; }

        public Enemy(Texture2D texture, Vector2 position, Rectangle screenBounds,IMovementBehaviour movementBehaviour) : base(texture, position, screenBounds,1,3,10)
        {
            Alive = true;
            MovementBehaviour = movementBehaviour;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (Alive)
            {
                MovementBehaviour.Move(gameTime, this);
            }

            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
            Position.X = MathHelper.Clamp(Position.X, 0, GameBounds.Width - Width);
        }
    }
}
