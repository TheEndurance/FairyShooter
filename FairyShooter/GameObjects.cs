using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class GameObjects
    {
        public Texture2D ProjectileTexture { get; set; }


        public GameObjects()
        {
           
        }
        public Fairy Fairy { get; set; }
        public IList<Projectile> Projectiles { get; set; }
    }
}