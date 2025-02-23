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
        public bool isCinemating { get; set; }

        private Vector2 targetPosition;
        private float speedTranslation;
        private bool hasCinematicPlayed = false;


        public CameraManager(float cameraPositionX, float cameraPositionY)
        {
            CameraPostion = new(cameraPositionX, cameraPositionY);
        }
        public void StartCinematic(float speed, float positionX, float positionY)
        {
            cinematicList.Add((speed, new Vector2(positionX, positionY)));

           if (hasCinematicPlayed == false)
           {
                isCinemating = true;
                speedTranslation = speed;
                targetPosition = new Vector2(positionX, positionY);
           }
        }
        public void Update()
        {
            if (isCinemating)
            {
                CameraPostion = Vector2.Lerp(CameraPostion, targetPosition, speedTranslation * Globals.DeltaTime);

                if (Vector2.Distance(CameraPostion, targetPosition) < 0.1f || CameraPostion == targetPosition)
                {
                    CameraPostion = targetPosition;
                    isCinemating = false;
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
