using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel.Scenes
{
    internal class SpaceScene : Scene, IScene
    {
        private ContentManager contentManager;
        private Texture2D spaceBackGround;
        private SceneManager sceneManager;
        public Dictionary<Vector2, int> Mg { get; }
        public Dictionary<Vector2, int> Fg { get; }
        public Dictionary<Vector2, int> Collisions { get; }
        public Dictionary<Vector2, int > NewFg { get; } = null;
        public Dictionary<Vector2, int> NewMg { get; } = null;


        GraphicsDeviceManager graphics;

        public SpaceScene(ContentManager contentManager, SceneManager sceneManager, GraphicsDeviceManager graphics) : base(contentManager, sceneManager, graphics) 
        {
            this.sceneManager = sceneManager;
            this.graphics = graphics;
            this.contentManager = contentManager;
            Mg = LoadMap("../../../Data/zaza_mg.csv");
            Fg = LoadMap("../../../Data/zaza_fg.csv");
            Collisions = LoadMap("../../../Data/zaza_collisions.csv");
            SpawnPointX = 451;
            SpawnPointY = 8320;
        }

        public override void Load()
        {
            spaceBackGround = contentManager.Load<Texture2D>("BackGrounds/1000");
        }
        public override void Update(GameTime gameTime)
        {
            Debug.WriteLine($"Mg count: {Mg.Count}");
            Debug.WriteLine($"Fg count: {Fg.Count}");
            Debug.WriteLine($"Collisions count: {Collisions.Count}");

        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(spaceBackGround, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
        }
    }
}
