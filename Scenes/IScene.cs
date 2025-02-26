using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel.Scenes
{
    internal interface IScene
    {
        public Dictionary<Vector2, int> Mg { get; }
        public Dictionary<Vector2, int> Fg { get; }
        public Dictionary<Vector2, int> Collisions { get; }
        public Dictionary<Vector2, int> NewMg { get; }
        public Dictionary<Vector2, int> NewFg { get; }
        public int SpawnPointX { get; set; }
        public int SpawnPointY { get; set; }
        public int SceneChangePointX { get; set; }
        public int SceneChangePointY { get; set; }
        public void Load();
        public void Update(GameTime gameTime);
        public void Draw();
    }
}
