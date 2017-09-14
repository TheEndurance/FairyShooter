using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    public class Fairy : Sprite
    {
        private readonly ProjectileManager _projectileManager;
        // Create a readonly variable which specifies how often the user can shoot.  Could be moved to a game settings area
        private static readonly TimeSpan ShootInterval = TimeSpan.FromMilliseconds(255);

        // Keep track of when the user last shot.  Or null if they have never shot in the current session.
        private TimeSpan? lastBulletShot;

        public Fairy(Texture2D texture, Vector2 location, Rectangle screenBounds, ProjectileManager projectileManager) : base(texture, location, screenBounds)
        {
            _projectileManager = projectileManager;
            Location.Y = GameBounds.Height - Height;
            Location.X = (float)GameBounds.Width / 2;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
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

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (lastBulletShot == null || gameTime.TotalGameTime - lastBulletShot >= ShootInterval)
                {
                    _projectileManager.Shoot(ProjectileType.Regular, Location.X, Location.Y, Width, Height, GameBounds);
                    lastBulletShot = gameTime.TotalGameTime;
                }
            }

            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
            Location.X = MathHelper.Clamp(Location.X, 0, GameBounds.Width - Width);
        }
    }
}