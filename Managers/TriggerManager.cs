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
        private Dictionary<string, List<TriggerBox>> sceneTriggers = new();

        private string currentScene = null;
        public TriggerManager(CameraManager cameraManager)
        {
            this.cameraManager = cameraManager;
            TriggerBoxTexture = Texture;
        }

        public TriggerBox AddTriggerBox(string sceneName, int positionX, int positionY, int width, int height, Color color, EventHandler eventHandler)
        {
            Texture2D triggerBoxTexture = new Texture2D(Globals.GraphicsDevice, 1, 1);
            triggerBoxTexture.SetData(new Color[] { color });
            TriggerBox triggerBox = new(triggerBoxTexture, new(positionX, positionY, width, height));
            triggerBox.OnIntersection += eventHandler;
            triggerStates.Add(triggerBox, false);

            if (!sceneTriggers.ContainsKey(sceneName))
                sceneTriggers[sceneName] = new List<TriggerBox>();

            sceneTriggers[sceneName].Add(triggerBox);

            Debug.WriteLine($"Ajout TriggerBox: {triggerBox.rect} - {triggerStates[triggerBox]}");
            return triggerBox;
        }
        public void ActivateTriggersForScene(string sceneName)
        {
            if (currentScene == sceneName)
            {
                Debug.WriteLine($"Scene {sceneName} already active");
                return;
            }

            triggerStates.Clear();

            if (sceneTriggers.TryGetValue(sceneName, out var triggers))
            {
                foreach (var trigger in triggers)
                {
                    triggerStates[trigger] = false;
                }
            }

            currentScene = sceneName;
            Debug.WriteLine($"{triggerStates.Count} triggers activated for the scene {sceneName}");
        }
        public void CheckTriggers(Player player)
        {
            foreach (var triggerBox in triggerStates.Keys)
            {
                if (triggerBox.rect.Intersects(player.rect) && !triggerStates[triggerBox])
                {
                    if (!cameraManager.IsCinemating)
                    {
                        triggerBox.Intersection();
                        triggerStates[triggerBox] = true;
                    }
                    break;
                }
            }
        }
        public void ClearTriggers()
        {
            triggerStates.Clear();
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
