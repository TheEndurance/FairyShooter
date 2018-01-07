﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FairyShooter
{
    public class CollisionManager
    {
        private readonly GameObjects _gameObjects;

        public CollisionManager(GameObjects gameObjects)
        {
            _gameObjects = gameObjects;
        }

        public void Update(GameTime gameTime)
        {
            CheckCollisions();
        }

        private void CheckCollisions()
        {
            CheckShotToPlayer();
            CheckShotToEnemy();
        }

        private void CheckShotToPlayer()
        {

            for (var i = 0; i < _gameObjects.ProjectileManager.EnemyProjectiles.Count; i++)
            {
                Projectile projectile = _gameObjects.ProjectileManager.EnemyProjectiles[i];
                Fairy fairy = _gameObjects.Fairy;
                if (projectile.BoundingBox.Intersects(fairy.BoundingBox) 
                    && !fairy.IsDead
                    && projectile.Shooter is Enemy)
                {
                    fairy.Hit();
                    if (fairy.IsDead)
                    {
                        _gameObjects.ExplosionManager.CreateExplosion(fairy);
                    }
                    _gameObjects.ProjectileManager.RemoveEnemyProjectile(projectile);
                }
            }
           
        }

        private void CheckShotToEnemy()
        {
            for (var i = 0; i < _gameObjects.ProjectileManager.PlayerProjectiles.Count; i++) {
                Projectile projectile = _gameObjects.ProjectileManager.PlayerProjectiles[i];


                for (var j = 0; j < _gameObjects.EnemyManager.Enemies.Count; j++)
                {
                    Enemy enemy = _gameObjects.EnemyManager.Enemies[j];
                    if (projectile.BoundingBox.Intersects(enemy.BoundingBox)
                        && !enemy.IsDead
                        && projectile.Shooter is Fairy)
                    {
                        enemy.Hit();
                        _gameObjects.ProjectileManager.RemovePlayerProjectile(projectile);
                        if (enemy.IsDead)
                        {
                            _gameObjects.ExplosionManager.CreateExplosion(enemy);
                        }
                    }
                }
            }
        }
    }
}