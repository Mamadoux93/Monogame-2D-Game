using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel.Managers
{
    internal class WindowResize
    {

        private readonly RenderTarget2D renderTarget;
        private readonly GraphicsDevice graphicsDevice;
        private Rectangle rect;

        public WindowResize(GraphicsDevice graphicsDevice, int width, int height)
        {
            graphicsDevice = this.graphicsDevice;
            renderTarget = new(graphicsDevice, width, height);
        }

        public void SetDestinationRectangle()
        {
            var screenSize = graphicsDevice.PresentationParameters.Bounds;

            float scaleX = (float)screenSize.Width / renderTarget.Width;
            float scaleY = (float)screenSize.Height / renderTarget.Height;
            float scale = Math.Min(scaleX, scaleY);

            int newWidth = (int)(renderTarget.Width * scale);
            int newHeight = (int)(renderTarget.Height * scale);

            int posX = (screenSize.Width - newWidth) / 2;
            int posY = (screenSize.Height - newHeight) / 2;

            rect = new(posX, posY, newWidth, newHeight);
        }

        public void Activate()
        {
            graphicsDevice.SetRenderTarget(renderTarget);
            graphicsDevice.Clear(Color.White);
        }

        public void Draw()
        {
            graphicsDevice.SetRenderTarget(null);
            graphicsDevice.Clear(Color.White);
            Globals.SpriteBatch.Begin();
            Globals.SpriteBatch.Draw(renderTarget, rect, Color.White);
            Globals.SpriteBatch.End();
        }

    }
}
