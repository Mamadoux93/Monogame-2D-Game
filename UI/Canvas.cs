using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel.UI
{
    internal class Canvas : IDraggable
    {
        public Texture2D texture;
        public Rectangle rect { get; set; }
        public Rectangle Rect { get; set; }

        private readonly int lastId = 0;
        public int ID { get; private set; }

        public bool Called { get; set; } = false;

        private Texture2D rectangleTexture = new(Globals.GraphicsDevice, 1, 1);
        private readonly List<Button> canvasButtons = new();
        public readonly List<Button> canvasCallButtons = new();
        private Point previousPosition;

        public Canvas(Texture2D texture, Rectangle rect)
        {
            this.texture = texture;
            this.rect = rect;
            previousPosition = rect.Location;
            (this as IDraggable).RegisterDraggable();
        }
        public Button AddButton(int positionX, int positionY, int width, int height, Color color)
        {
            if (positionX < 0) { positionX = 0; }
            if (positionY < 0) { positionY = 0; }
            if (positionX > rect.Width) { positionX = rect.Width - width; }
            if (positionY > rect.Height) { positionY = rect.Height - height; }
            Texture2D buttonTexture = new Texture2D(Globals.GraphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { color });
            Button button = new(buttonTexture, new(rect.X + positionX, rect.Y + positionY, width, height));
            canvasButtons.Add(button);
            return button;
        }
        public Button AddButtonToCall(int positionX, int positionY, int width, int height, Color color)
        {
            Texture2D buttonTexture = new Texture2D(Globals.GraphicsDevice, 1, 1);
            buttonTexture.SetData(new[] { color });
            Button button = new(buttonTexture, new(positionX, positionY, width, height), ID);
            canvasCallButtons.Add(button);
            return button;
        }
        public void Update()
        {
            DragDropManager.Update();
            if (previousPosition != rect.Location)
            {
                int deltaX = rect.X - previousPosition.X;
                int deltaY = rect.Y - previousPosition.Y;

                foreach (var button in canvasButtons)
                {
                    button.rect = new Rectangle(button.rect.X + deltaX, button.rect.Y + deltaY, button.rect.Width, button.rect.Height);
                }

                previousPosition = rect.Location;
            }

            foreach (var button in canvasButtons)
            {
                button.Update();
            }
            foreach (var button in canvasCallButtons)
            {
                button.Update();
            }
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(texture, rect, Color.White);
            if (Called)
            {
                foreach (var button in canvasButtons)
                {
                    button.Draw();
                }
            }

            foreach (var button in canvasCallButtons)
            {
                button.Draw();
            }

        }

    }
}
