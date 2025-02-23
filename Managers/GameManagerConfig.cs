using Microsoft.Xna.Framework;
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
        public GraphicsDeviceManager GraphicsDeviceManager { get; init; }
    }
}
