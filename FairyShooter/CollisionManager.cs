using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class CollisionManager
    {
        private Fairy _fairy;
        private ProjectileManager _projectileManager;
        private EnemyManager _enemyManager;

        public CollisionManager(Fairy fairy, ProjectileManager projectileManager, EnemyManager enemyManager)
        {
            _fairy = fairy;
            _projectileManager = projectileManager;
            _enemyManager = enemyManager;
        }

        public void Update(GameTime gameTime)
        {
            CheckCollisions();
        }

        private void CheckCollisions()
        {
            CheckShotToPlayer();
        }

        private void CheckShotToPlayer()
        {

            foreach (var projectile in _projectileManager.AllProjectiles)
            {
                if (projectile.BoundingBox.Intersects(_fairy.BoundingBox) & projectile.Shooter is Enemy)
                {
                    _fairy.Hit();
                }
                foreach (var enemy in _enemyManager.Enemies)
                {
                    if (projectile.BoundingBox.Intersects(enemy.BoundingBox) & projectile.Shooter is Fairy)
                    {
                        enemy.Hit();
                    }
                }
                
            }
           
        }
    }
}
