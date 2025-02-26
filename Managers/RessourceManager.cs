using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel
{
    internal class RessourceManager
    {
        public static Dictionary<string, Texture2D> Textures { get; set; } = new Dictionary<string, Texture2D>();

        public static Dictionary<Vector2, int> Tiles { get; } = new Dictionary<Vector2, int>();

        //private Texture2D rectangleTexture = new(Globals.GraphicsDevice, 1, 1);

        public void LoadContent(ContentManager contentManager)
        {
            Textures["fireball"] = contentManager.Load<Texture2D>("fireball");
            Textures["player_static"] = contentManager.Load<Texture2D>("player_static");
            Textures["Mushroom"] = contentManager.Load<Texture2D>("Mushroom");
            Textures["player_static"] = contentManager.Load<Texture2D>("player_static");
            //Textures["rectangleTexture"] = rectangleTexture;
        }
        public Texture2D GetTexture(string key)
        {
            return Textures.ContainsKey(key) ? Textures[key] : null;
        }

        public RessourceManager() 
        { 

        }
    }
}
