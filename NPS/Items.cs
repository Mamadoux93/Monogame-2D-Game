using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UltraLongMonogameTutoriel.NPS;

namespace UltraLongMonogameTutoriel
{
    internal class Items : Sprite , IItems
    {
        public bool Summoned { get; set; } = false;

        public Items(Texture2D texture, Rectangle rect, Rectangle srect) : base(texture, rect, srect) 
        {
            Direction = 1;
        }
        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            velocity.Y += 50f * deltaTime;

            velocity.Y = Math.Min(25.0f, velocity.Y);

            velocity.X = Math.Max(-30, Math.Min(30, velocity.X)); // entre -30 et 30 de vitesse X
            velocity.Y = Math.Max(-10, Math.Min(30, velocity.Y));

            velocity.X += 15f * deltaTime;
            
            if (Iced)
            {
                velocity.X *= 1.0f;
            }
            else
            {
                velocity.X *= 0.95f;
            }


            /*if(Walled)
            {
                Direction *= -1;
            }*/

            //Debug.WriteLine($"{Direction}");
            //Debug.WriteLine($"{velocity.X}");  

        }
        
    }
}
