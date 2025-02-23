using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel.Managers
{
    internal class CameraManager
    {
        public Vector2 CameraPostion { get; set; }

        private List<(float speed, Vector2 targetPosition)> cinematicList = new List<(float, Vector2)>();
        public bool IsCinemating { get; set; }
        public bool FirstCinematic { get; set; }

        GraphicsDeviceManager graphics;


        private Vector2 targetPosition;
        private float speedTranslation;
        private bool hasCinematicPlayed = false;

        public CameraManager(float cameraPositionX, float cameraPositionY, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            CameraPostion = new(cameraPositionX, cameraPositionY);
            FirstCinematic = true;
        }

        public void StartCinematic(float speed, float positionX, float positionY)
        {
            Vector2 adjustedTargetPosition = new Vector2(positionX + (graphics.PreferredBackBufferWidth / 2), positionY + (graphics.PreferredBackBufferHeight / 2));

            cinematicList.Add((speed, adjustedTargetPosition));

           if (hasCinematicPlayed == false)
           {
                IsCinemating = true;
                speedTranslation = speed;
                targetPosition = adjustedTargetPosition;
           }
        }
        public void Update()
        {
            if (IsCinemating)
            {
                CameraPostion = Vector2.Lerp(CameraPostion, targetPosition, speedTranslation * Globals.DeltaTime);

                if (Vector2.Distance(CameraPostion, targetPosition) < 10.0f || CameraPostion == targetPosition)
                {
                    CameraPostion = targetPosition;
                    IsCinemating = false;
                    hasCinematicPlayed = true;
                    Debug.WriteLine($"Cinematic finished! at {CameraPostion.X} - {CameraPostion.Y}");
                }
            }
        }
        public void ResetCinematic()
        {
            hasCinematicPlayed = false;
        }
    }
}
