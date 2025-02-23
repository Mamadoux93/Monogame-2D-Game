using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel
{
    public class Timer
    {
        private float timer;

        private readonly float totalTime;

        public bool Active { get; set; }



        public Timer(float totalTime)
        {
            this.timer = 0f;
            this.totalTime = totalTime;
            this.Active = false;
        }

        

        public void StartTimer()
        {
            Active = true;
            timer = 0.0f;
        }

        public void Update(GameTime gameTime)
        {
            if (Active)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer >= totalTime)
                {
                    Active = false;
                }
            }
            
        }
    }
}
