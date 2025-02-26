using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel.Managers
{
    internal class GameManagerConfig
    {
        public Player Player { get; init; }
        public CameraManager CameraManager { get; init; }
        public RessourceManager RessourceManager { get; init; }
        public List<Sprite> UsableItems { get; init; }
        public GraphicsDeviceManager _GraphicsDeviceManager { get; init; }
        public SceneManager SceneManager { get; init; }
        public TriggerManager TriggerManager { get; init; }
        public ContentManager ContentManager { get; init; }
    }
}
