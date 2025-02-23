using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UltraLongMonogameTutoriel.Managers;

namespace UltraLongMonogameTutoriel.NPS
{
    internal class EnemyZebi : Sprite, INps, IEnemy
    {
        private readonly Timer jumpCooldown;
        public Timer DeathCooldown { get; }
        public bool Dead { get; set; }
        public bool Deplacé { get; set; } = false;
        public bool Summoned { get; set; } = false;
        public EnemyZebi(Texture2D texture, Rectangle rect, Rectangle srect) : base(texture, rect, srect)
        {
            Grounded = false;
            Dead = false;
            Iced = false;
            Direction = -1;
            jumpCooldown = new Timer(0.5f);
            DeathCooldown = new Timer(1.5f);
            Dead = false;
            velocity = Vector2.Zero;
        }
        public override void Update(GameTime gameTime)
        {
            int prevDirection = Direction;

            velocity.Y += 50f * Globals.DeltaTime;

            velocity.Y = Math.Min(25.0f, velocity.Y);

            velocity.X = Math.Max(-30, Math.Min(30, velocity.X)); // entre -30 et 30 de vitesse X
            velocity.Y = Math.Max(-10, Math.Min(30, velocity.Y));

            if (!jumpCooldown.Active && !Dead && Globals.NPS_Awarness)
            {
                Deplacement(rect, gameTime, 800, 1200);
            }


            if (velocity.X > 0)
            {
                Direction = 1;
            }
            else
            {
                Direction = -1;
            }

            if (Iced)
            {
                velocity.X *= 1.0f;
            }
            else
            {
                velocity.X *= 0.95f;
            }

            if (prevDirection != Direction)
            {
                srect.X += srect.Width;
                srect.Width *= -1;
                velocity.Y += -800 * Globals.DeltaTime;
                jumpCooldown.StartTimer();
            }

            if (Dead && !DeathCooldown.Active)
            {
                Debug.WriteLine($"Enemy {rect.X}, {rect.Y} DeathCooldown fini !");
            }


            //Debug.WriteLine($"X:{rect.X} - Y:{rect.Y} - {Deplacé}");

            jumpCooldown.Update(gameTime);
        }

        // déplacement d'un point A à un point B
        public void Deplacement(Rectangle? rect, GameTime gameTime, float position1, float position2)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            float moveSpeed = 30f * deltaTime;

            if (!rect.HasValue)
            {
                return;
            }

            int rectX = rect.Value.X;

            if (position1 < position2)
            {
                if ((position1 < rectX || position1 >= rectX) && (rectX < position2 || rectX >= position2))
                {
                    if (Deplacé)
                    {
                        velocity.X += moveSpeed;
                    }
                    else if (!Deplacé)
                    {
                        velocity.X += -moveSpeed;
                    }
                }

            }
            else
            {
                if ((position1 > rectX || position1 <= rectX) && (rectX > position2 || rectX <= position2))
                {
                    if (Deplacé)
                    {
                        velocity.X += moveSpeed;
                    }
                    else if (!Deplacé)
                    {
                        velocity.X += -moveSpeed;
                    }
                }
            }

            if (rectX <= position1)
            {
                Deplacé = true;
            }
            else if (rectX >= position2)
            {
                Deplacé = false;
            }

        }

        public new void Summon()
        {
            Summoned = true;
        }
    }
}
