using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel.UI
{
    internal class Button
    {
        public Texture2D texture;

        public Rectangle rect;
        private Color ButtonColor { get; set; } = Color.Crimson;

        public int ID { get; set; }
        public Color QuandTuPassesAuDessusAvecTonCurseur { get; set; } = Color.DarkRed;

        public Button(Texture2D texture, Rectangle rect, int ID)
        {
            this.texture = texture;
            this.rect = rect;
            this.ID = ID;
        }

        public Button(Texture2D texture, Rectangle rect)
        {
            this.texture = texture;
            this.rect = rect;
        }

        public void Update()
        {
            if (Globals.MouseCursor.Intersects(rect))
            {
                texture.SetData(new Color[] { QuandTuPassesAuDessusAvecTonCurseur });
                if (Globals.Clicked)
                {
                    Click();
                }
            }
            else
            {
                texture.SetData(new Color[] { ButtonColor });
            }

        }

        public event EventHandler OnClick;

        private void Click()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(texture, rect, ButtonColor);
        }

        public void Draw(Vector2 camera)
        {
            Globals.SpriteBatch.Draw(texture, new Rectangle(rect.X + (int)camera.X, rect.Y + (int)camera.Y, rect.Width, rect.Height), ButtonColor);
        }
    }
}
