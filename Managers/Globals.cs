using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLongMonogameTutoriel.Managers
{
    internal static class Globals
    {
        public static ContentManager Content { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static MouseState MouseState { get; set; }
        public static MouseState LastMouseState { get; set; }
        public static bool Clicked { get; set; }
        public static bool Drag { get; set; }
        public static Rectangle MouseCursor { get; set; }
        public static Player Player { get; set; }
        public static List<Sprite> UsableItems { get; set; }
        public static float TotalTime { get; set; }
        public static float DeltaTime { get; set; }
        public static int TILESIZE { get; set; } = 64;
        public static bool NPS_Awarness { get; set; } = true;

        public static bool LevelChange { get; set; } = true;

        public static void Update(GameTime gameTime)
        {
            LastMouseState = MouseState;
            MouseState = Mouse.GetState();

            Clicked = MouseState.LeftButton == ButtonState.Pressed && LastMouseState.LeftButton == ButtonState.Released;
            Drag = MouseState.LeftButton == ButtonState.Pressed;
            MouseCursor = new(MouseState.Position.X, MouseState.Position.Y, 0, 0);

            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TotalTime = (float)gameTime.TotalGameTime.TotalSeconds;

        }
    }
}
