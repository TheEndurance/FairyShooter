using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FairyShooter
{
    public class Explosion : Sprite
    {
        public Explosion(Texture2D texture, Vector2 position, Rectangle gameBounds) : base(texture, position, gameBounds, 5, 8, 30)
        {

        }

        protected override void CheckBounds()
        {
          
        }

        public bool AnimationComplete()
        {
            return AnimationOncePlayed;
        }
    }
}
