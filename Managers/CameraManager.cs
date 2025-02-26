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

        public Timer CinematicEndTimer { get; set; }

        private Vector2 targetPosition;
        private float speedTranslation;
        public CameraManager(float cameraPositionX, float cameraPositionY, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            CameraPostion = new(cameraPositionX, cameraPositionY);
            FirstCinematic = true;
        }

        public void StartCinematic(float speed, float positionX, float positionY, float cinematicEndTimer)
        {
            Vector2 adjustedTargetPosition = new Vector2(positionX + (graphics.PreferredBackBufferWidth / 2), positionY + (graphics.PreferredBackBufferHeight / 2));


            cinematicList.Add((speed, adjustedTargetPosition));

            IsCinemating = true;
            speedTranslation = speed;
            targetPosition = adjustedTargetPosition;

            CinematicEndTimer = new(cinematicEndTimer);
            CinematicEndTimer.StartTimer();
           
        }
        public void Update(GameTime gameTime)
        {
            if (IsCinemating)
            {
                CameraPostion = Vector2.Lerp(CameraPostion, targetPosition, speedTranslation * Globals.DeltaTime);

                if (Vector2.Distance(CameraPostion, targetPosition) < 1.0f || CameraPostion == targetPosition)
                {
                    CameraPostion = targetPosition;

                    if(!CinematicEndTimer.Active) 
                    {
                        cinematicList.Clear();
                        IsCinemating = false;
                    }

                    if(cinematicList.Count > 0)
                    {
                        cinematicList.RemoveAt(0);
                    }

                    Debug.WriteLine($"Cinematic finished at {CameraPostion.X} - {CameraPostion.Y}");
                }
            }

            //Debug.WriteLine($"Cinematic - CameraPos: {CameraPostion}, TargetPos: {targetPosition}, Distance: {Vector2.Distance(CameraPostion, targetPosition)}, TimerActive: {CinematicEndTimer?.Active} isCinemating : {IsCinemating}");
            CinematicEndTimer?.Update(gameTime);
            
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return screenPosition - CameraPostion;
        }
    }
}
