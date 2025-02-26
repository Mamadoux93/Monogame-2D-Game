using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.Managers;
using System.Diagnostics;

namespace UltraLongMonogameTutoriel
{
    internal class TriggerBox
    {
        public Texture2D texture;
        public Rectangle rect;
        private Player player;
        public Color SpriteColor { get; set; } = Color.White;
        public TriggerBox(Texture2D texture, Rectangle rect) 
        {

            this.texture = texture;
            this.rect = rect;
        }

        public event EventHandler OnIntersection;

        public void Update()
        {

        }
        public void Intersection()
        {
            if (OnIntersection != null)
            {
                OnIntersection.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Debug.WriteLine("No event is assigned to this trigger");
            }
        }

        public void Draw(Vector2 camera)
        {
            Globals.SpriteBatch.Draw(texture, new Rectangle(rect.X + (int)camera.X, rect.Y + (int)camera.Y, rect.Width, rect.Height), SpriteColor);
        }
    }
}
