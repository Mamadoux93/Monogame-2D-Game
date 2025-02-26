using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Reflection.Metadata;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel
{
    internal class Player : Sprite
    {
        private int health;
        private const int numbJumps = 2;
        public int JumpCounter { get; set; }
        public int Health 
        { 
            get
            {
                return health;
            }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if(value > 100)
                {
                    health = 100;
                    Coins += 50;
                }
                else
                {
                    health = value;
                }
            }
        }
        public int Coins { get; set; }
        public bool Invincibility { get; set; } = false;
        public Timer InvincibilityTimer {  get; }
        public Timer InvincibilityBlink { get; }
        public Timer IcedTimer { get; }
        public bool FuckingRetardedBlockIHaveToUseABoolForDisShit { get; set; } = false;

        CameraManager cameraManager;

        public Player(Texture2D texture, Rectangle rect, Rectangle srect, CameraManager cameraManager) : base(texture, rect, srect)
        {
            this.cameraManager = cameraManager;
            Health = 50;
            Coins = 0;
            JumpCounter = 0;
            this.InvincibilityTimer = new Timer(5.0f);
            this.InvincibilityBlink = new Timer(0.5f);
        }


        public override void Update(KeyboardState keystate, KeyboardState prevKeystate, GameTime gameTime)
        {


            int prevDirection = Direction;


            float moveSpeed = 40f * Globals.DeltaTime;

            float gravity = 35f * Globals.DeltaTime;

            velocity.Y += gravity;

            velocity.Y = Math.Min(25.0f, velocity.Y);

            if (!cameraManager.IsCinemating)
            {
                if (keystate.IsKeyDown(Keys.D))
                {
                    velocity.X += moveSpeed;
                    Direction = 1;
                    Debug.WriteLine($"position: {rect.X} - {rect.Y} - {cameraManager.CameraPostion.X} - {cameraManager.CameraPostion.Y}");

                }
                else if (keystate.IsKeyDown(Keys.Q))
                {
                    velocity.X += -moveSpeed;
                    Direction = -1;
                    Debug.WriteLine($"position: {rect.X} - {rect.Y} -  {cameraManager.CameraPostion.X} - {cameraManager.CameraPostion.Y}");
                }
                if ((Walled || (JumpCounter < numbJumps)) && keystate.IsKeyDown(Keys.Space) && !prevKeystate.IsKeyDown(Keys.Space))
                {
                    velocity.Y = 0;
                    velocity.Y += -1000 * Globals.DeltaTime;
                    JumpCounter++;
                }
            }


            velocity.X = Math.Max(-50, Math.Min(50, velocity.X)); // entre -20 et 20 de vitesse X
            velocity.Y = Math.Max(-20, Math.Min(20, velocity.Y)); // entre -20 et 20 de vitesse Y

            if (Iced && Grounded)
            {
                velocity.X *= 1;
            }
            else if (Iced && !Grounded)
            {
                velocity.X *= 0.95f;
            }
            else
            {
                Iced = false;
                velocity.X *= 0.95f;
            }

            if (Walled)
            {
                Iced = false;
                velocity.X *= 0.000002f;
                JumpCounter = 0;
            }
            


            
            
            if (prevDirection != Direction)
            {
                srect.X += srect.Width;
                srect.Width *= -1;
            }

            if (!InvincibilityTimer.Active)
            {
                Invincibility = false;
                SpriteColor = Color.White;
                InvincibilityBlink.Active = false;
            }
            else if (Invincibility)
            {
                if (!InvincibilityBlink.Active)
                {
                    //SpriteColor = SpriteColor == Color.White ? Color.Transparent : Color.White;
                    if (SpriteColor == Color.White)
                    {
                        SpriteColor = Color.Transparent;
                    }
                    else
                    {
                        SpriteColor = Color.White;
                    }
                    InvincibilityBlink.StartTimer();
                }
            }



            InvincibilityTimer.Update(gameTime);
            InvincibilityBlink.Update(gameTime);


            /*Debug.Write($"velocity.Y: {velocity.Y}");
              Debug.WriteLine($" velocity.X: {velocity.X}");
              Debug.WriteLine($"Invincibility: {Invincibility} - {invincibilityTimer.Active}");
              Debug.WriteLine($"Invincibility Timer: {invincibilityTimer.Active}");
              Debug.WriteLine($"Blink Timer: {invincibilityBlink.Active}");
              Debug.WriteLine($"IsVisible: {IsVisible}");
              Debug.WriteLine($"position: {rect.X} - {rect.Y}");
              Debug.WriteLine($"{jumpCounter}");
              Debug.WriteLine($"{Grounded}");
              if(velocity.Y > 0.0f)
              {
                  Debug.WriteLine("zaza");
              }*/
           //Debug.WriteLine($"position: {rect.X} - {rect.Y}");
            //Debug.WriteLine($"Health: {Health}");
            //Debug.WriteLine($"{Coins}");
            //Debug.Write($"velocity.Y: {velocity.Y}");
           // Debug.WriteLine($" velocity.X: {velocity.X}");
            //Debug.WriteLineIf(Iced,$"Walled:{Walled} - Grounded: {Grounded} Iced: {Iced}");
        }

        public void StartInvincibility()
        {
            Invincibility = true;
            SpriteColor = Color.White;
            InvincibilityTimer.StartTimer();
            InvincibilityBlink.StartTimer();
        }

        public void Respawn(int spawnPointX, int spawnPointY)
        {
            // En mode la ca réinitialise tt quand ca respawn aulieu de recréer une instance qui va tout faire bugguer
            rect = new Rectangle(spawnPointX, spawnPointY, Globals.TILESIZE, Globals.TILESIZE);
            velocity.X = 0;
            velocity.Y = 0;
            Health = 50;
        }

        public void HealthMethod(int spawnPointX, int spawnPointY)
        {
            if (rect.Y > 9000 || Health <= 0)
            {
                Respawn(spawnPointX, spawnPointY);
            }

            if (Health == 100)
            {
                rect.Height = Globals.TILESIZE * 2;
            }
            else if (Health <= 50)
            {
                rect = new Rectangle(rect.X, rect.Y, Globals.TILESIZE, Globals.TILESIZE);
            }
        }
    }

}

    
