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

        public IMovementBehaviour MovementBehaviour { get; set; }
        public IShootingBehaviour ShootingBehaviour { get; set; }

        public Enemy(Texture2D texture, Vector2 position, Rectangle screenBounds,IMovementBehaviour movementBehaviour) : base(texture, position, screenBounds,1,3,10)
        {
            MovementBehaviour = movementBehaviour;
            ShootingBehaviour = new SlowEnemyShootingBehaviour();
            Direction = 1;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
   
                MovementBehaviour.Move(gameTime, this);
                ShootingBehaviour.Shoot(gameTime, gameObjects.ProjectileManager, this);
     

            base.Update(gameTime, gameObjects);
        }

        public void Hit()
        {
            IsDead = true;
        }
    }
}
