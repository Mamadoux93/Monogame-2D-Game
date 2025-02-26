using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.Managers;
using System.IO;

namespace UltraLongMonogameTutoriel.Scenes
{
    internal class Scene
    {
        private ContentManager contentManager;
        private SceneManager sceneManager;
        private Texture2D balandrouille;
        GraphicsDeviceManager graphics;
        public int SpawnPointX { get; set; }
        public int SpawnPointY { get; set; }

        public Scene(ContentManager contentManager, SceneManager sceneManager, GraphicsDeviceManager graphics)
        {
            this.sceneManager = sceneManager;
            this.graphics = graphics;
            this.contentManager = contentManager;
        }
        public virtual void Load()
        {

        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw()
        {


        }
        // Opens a CSV file, reads it line by line, splits the line into
        // an array of integers. Converts data into a Dictionary where the
        // keys is the physical position of the number in the file
        // (e.g. line 3, column 2) => (2, 1)).
        public Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();

            StreamReader reader = new(filepath);

            int y = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {

                string[] items = line.Split(',');

                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        if (value > -1)
                        {
                            result[new Vector2(x, y)] = value;
                        }
                    }
                }
                y++;

            }

            return result;
        }
    }
}
