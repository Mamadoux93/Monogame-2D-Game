using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraLongMonogameTutoriel.UI;
using System.Diagnostics;

namespace UltraLongMonogameTutoriel.Managers
{
    internal class TriggerManager
    {
        private Texture2D TriggerBoxTexture { get; }

        private Texture2D Texture = new(Globals.GraphicsDevice, 1, 1);

        private CameraManager cameraManager;

        private Dictionary<TriggerBox, bool> triggerStates = new();
        public TriggerManager(CameraManager cameraManager)
        {
            this.cameraManager = cameraManager;
            TriggerBoxTexture = Texture;
        }

        public TriggerBox AddTriggerBox(int positionX, int positionY, int width, int height, Color color)
        {
            Texture2D triggerBoxTexture = new Texture2D(Globals.GraphicsDevice, 1, 1);
            triggerBoxTexture.SetData(new Color[] { color });
            TriggerBox triggerBox = new(triggerBoxTexture, new(positionX, positionY, width, height));
            triggerStates.Add(triggerBox, false);

            Debug.WriteLine($"Ajout TriggerBox: {triggerBox.rect} - {triggerStates[triggerBox]}");
            return triggerBox;
        }

        public void CheckTriggers(Player player, CameraManager cameraManager)
        {
            foreach (var triggerBox in triggerStates.Keys)
            {
                if (triggerBox.rect.Intersects(player.rect) && !triggerStates[triggerBox])
                {
                    cameraManager.isCinemating = true;
                    triggerStates[triggerBox] = true;
                    break;
                }
            }
        }

        public void Update()
        {
            foreach (var triggerBox in triggerStates)
            {
                triggerBox.Key.Update();
            }
        }
        public void Draw()
        {

            foreach(var triggerBox in triggerStates)
            {
                triggerBox.Key.Draw(cameraManager.CameraPostion);
            }
        }
    }
}
