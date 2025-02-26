using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel.Scenes
{
    internal class GameStartScene : Scene,  IScene
    {
        private ContentManager contentManager;
        private SceneManager sceneManager;
        private Texture2D balandrouille;
        GraphicsDeviceManager graphics;
        public Dictionary<Vector2, int> Mg { get; }
        public Dictionary<Vector2, int> Fg { get; }
        public Dictionary<Vector2, int> Collisions { get; }
        public Dictionary<Vector2, int> NewFg { get; }
        public Dictionary<Vector2, int> NewMg { get; }

        public GameStartScene(ContentManager contentManager, SceneManager sceneManager, GraphicsDeviceManager graphics) : base(contentManager, sceneManager, graphics)
        {
            this.sceneManager = sceneManager;
            this.graphics = graphics;
            this.contentManager = contentManager;
            SpawnPointX = 103;
            SpawnPointY = 7168;
            Fg = LoadMap("../../../Data/level2_fg.csv");
            Mg = LoadMap("../../../Data/level2_mg.csv");
            Collisions = LoadMap("../../../Data/Level2_collisions.csv");
            NewFg = LoadMap("../../../Data/Level2_newfg.csv");
            NewMg = LoadMap("../../../Data/Level2_newmg.csv");

        }

        public override void Load()
        {
            balandrouille = contentManager.Load<Texture2D>("BackGrounds/Balandrouille-Cat3");
        }
        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(balandrouille, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
        }
    }
}
