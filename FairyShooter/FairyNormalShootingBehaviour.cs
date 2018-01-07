﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace FairyShooter
{
    public class FairyNormalShootingBehaviour : IShootingBehaviour
    {
        public TimeSpan ShootInterval { get; }
        public TimeSpan? LastProjectileShot { get; set; }
        public FairyNormalShootingBehaviour()
        {
            ShootInterval = TimeSpan.FromMilliseconds(255);
            LastProjectileShot = null;

        }

        public void Shoot(GameTime gameTime, ProjectileManager projectileManager, Sprite shooter)
        {
           if (!shooter.IsDead)
                if (LastProjectileShot == null || gameTime.TotalGameTime - LastProjectileShot >= ShootInterval)
                {
                    projectileManager.Shoot(ProjectileType.Regular, shooter);
                    LastProjectileShot = gameTime.TotalGameTime;
                }
           
        }
    }
}