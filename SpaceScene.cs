using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel
{
    internal class SpaceScene : IScene
    {
        private ContentManager contentManager;
        private Texture2D spaceBackGround;
        private SceneManager sceneManager;
        GraphicsDeviceManager graphics;
        public SpaceScene(ContentManager contentManager,SceneManager sceneManager, GraphicsDeviceManager graphics) 
        {
            this.sceneManager = sceneManager;
            this.graphics = graphics;
            this.contentManager = contentManager;
            
        }

        public void Load()
        {
            spaceBackGround = contentManager.Load<Texture2D>("BackGrounds/1000");
        }
        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                sceneManager.AddScene(new GameStartScene(contentManager, sceneManager, graphics));
                    
            }
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(spaceBackGround, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
        }
    }
}
