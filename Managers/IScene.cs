using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel.Managers
{
    internal interface IScene
    {
        public void Load();

        public void Update(GameTime gameTime);

        public void Draw();
    }
}
