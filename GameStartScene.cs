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

namespace UltraLongMonogameTutoriel
{
    internal class GameStartScene : IScene
    {
        private ContentManager contentManager;
        private SceneManager sceneManager;
        GraphicsDeviceManager graphics;
        public GameStartScene(ContentManager contentManager, SceneManager sceneManager, GraphicsDeviceManager graphics)
        {
            this.sceneManager = sceneManager;
            this.graphics = graphics;
            this.contentManager = contentManager;

        }

        public void Load()
        {
            
        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {
            
        }
    }
}
