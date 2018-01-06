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


        public Enemy(Texture2D texture, Vector2 position, Rectangle gameBounds,IMovementBehaviour movementBehaviour) : base(texture, position, gameBounds)
        {
            Alive = true;
            MovementBehaviour = movementBehaviour;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (Alive)
            {
                MovementBehaviour.Move(gameTime, this);
            }
            base.Update(gameTime, gameObjects);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, Color.White);
           
        }

        protected override void CheckBounds()
        {
        }
    }
}
