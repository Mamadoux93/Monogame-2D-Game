using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace UltraLongMonogameTutoriel.NPS
{
    public interface INps
    {
        public bool Summoned { get; set; }
        void Summon();
        void Deplacement(Rectangle? rect, GameTime gameTime, float position1 = 0, float position2 = 0);
    }
}
