using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.UI;

namespace UltraLongMonogameTutoriel.Managers
{
    internal class UIManager
    {
        private Texture2D ButtonTexture { get; }

        private Texture2D rectangleTexture = new(Globals.GraphicsDevice, 1, 1);
        private SpriteFont Font { get; }

        private readonly List<Button> buttons = new();
        private readonly List<Canvas> canvasList = new List<Canvas>();

        public UIManager()
        {
            ButtonTexture = rectangleTexture;
        }

        public Canvas AddCanvas(int positionX, int positionY, int Width, int Height)
        {
            Texture2D canvasTexture = new Texture2D(Globals.GraphicsDevice, 1, 1);
            canvasTexture.SetData(new Color[] { Color.Gray });
            Canvas canvas = new(canvasTexture, new(positionX, positionY, Width, Height));
            canvas.AddButtonToCall(0, 100, 90, 90, Color.Aqua).OnClick += CallCanvas;
            canvas.AddButton(500000, 50000, 90, 90, Color.Aqua);
            canvasList.Add(canvas);
            return canvas;
        }

        public Button AddButton(int positionX, int positionY, int width, int height, Color color)
        {
            Texture2D buttonTexture = new Texture2D(Globals.GraphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { color });
            Button button = new(buttonTexture, new(positionX, positionY, width, height));
            buttons.Add(button);
            return button;
        }

        public void CallCanvas(object sender, EventArgs e)
        {
            foreach (Canvas canvas in canvasList)
            {
                foreach (var button in canvas.canvasCallButtons)
                {
                    if (button.ID == canvas.ID)
                    {
                        canvas.Called = !canvas.Called;
                    }
                }
            }
        }
        public void Update()
        {
            foreach (var canvas in canvasList)
            {
                canvas.Update();
            }
            foreach (var button in buttons)
            {
                button.Update();
            }
        }

        public void Draw()
        {
            foreach (var button in buttons)
            {
                button.Draw();
            }

            foreach (var canvas in canvasList)
            {
                if (!canvas.Called)
                {
                    foreach (var button in canvas.canvasCallButtons)
                    {
                        if (button.ID == canvas.ID)
                        {
                            button.Draw();
                            break;
                        }
                    }
                }
                if (canvas.Called)
                {
                    canvas.Draw();
                }
            }
        }
    }
}
