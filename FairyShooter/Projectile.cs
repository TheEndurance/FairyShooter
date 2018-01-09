using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class Projectile : Sprite
    {
        public Sprite Shooter{ get; private set; }
        public IMovementBehaviour MovementBehaviour { get; set; }
        public Projectile(Texture2D texture, Vector2 position, Sprite shooter, Rectangle gameBounds,int row = 1,int column = 1,int framePerSecond = 1) : base(texture, position, gameBounds, row,column,framePerSecond)
        {
            Shooter = shooter;
            Direction = shooter.Direction;
            MovementBehaviour = new RegularProjectileMovement();
        }

        protected override void CheckBounds()
        {

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
          
           MovementBehaviour.Move(gameTime,this);


            base.Update(gameTime, gameObjects);
        }

    }
}