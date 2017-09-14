using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class ProjectileManager
    {
        private GameObjects _gameObjects;

        public ProjectileManager(GameObjects gameObjects)
        {
            _gameObjects = gameObjects;
        }

        public void Shoot(ProjectileType projectileType, float X, float Y, int Width, int Height, Rectangle GameBounds)
        {
            if (projectileType == ProjectileType.Regular)
            {
                _gameObjects.Projectiles.Add(new Projectile(_gameObjects.ProjectileTexture,
                    new Vector2(X + Width / 2, Y), GameBounds));
            }
        }
    }

    public enum ProjectileType
    {
        Regular
    }
}
