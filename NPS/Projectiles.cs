using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel.NPS
{
    internal class Projectiles : Sprite, IItems, INps
    {
        public bool Summoned { get; set; } = false;
        public Projectiles(Texture2D texture, Rectangle rect, Rectangle srect) : base(texture, rect, srect)
        {

        }
        public Projectiles(Texture2D texture, Rectangle rect) : base(texture, rect)
        {

        }

        public override void Update(GameTime gameTime)
        {

            velocity.Y += 50f * Globals.DeltaTime;

            velocity.Y = Math.Min(25.0f, velocity.Y);

            velocity.X = Math.Max(-30, Math.Min(30, velocity.X)); // entre -30 et 30 de vitesse X
            velocity.Y = Math.Max(-10, Math.Min(30, velocity.Y));

            Deplacement(rect, gameTime);

            base.Update(gameTime);
        }

        public void Deplacement(Rectangle? rect, GameTime gameTime, float position1 = 0, float position2 = 0)
        {
            velocity.X = 1000 * Globals.DeltaTime * Direction;

            if (velocity.Y > 0 && Grounded)
            {
                velocity.Y -= 500 * Globals.DeltaTime;
            }
        }

        public new void Summon()
        {
            Summoned = true;
        }
    }
}
