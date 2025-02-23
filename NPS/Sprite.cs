using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace UltraLongMonogameTutoriel;

public class Sprite
{
    public Texture2D texture;

    public Rectangle rect;
    public Rectangle srect;
    public Vector2 velocity;
    public Color SpriteColor { get; set; } = Color.White;
    public bool Grounded { get; set; }
    public bool Iced { get; set; }
    public bool Sticky { get; set; }
    public int Direction { get; set; } // -1 left, 1 right
    public bool Walled { get; set; } = false;
    public Sprite(Texture2D texture, Rectangle rect, Rectangle srect)
    {
        this.texture = texture;
        this.rect = rect;
        this.srect = srect;
        Direction = -1;
        velocity = new();
    }
    public Sprite(Texture2D texture, Rectangle rect)
    {
        this.texture = texture;
        this.rect = rect;
        Direction = -1;
        velocity = new();
    }
    public virtual void Update(KeyboardState keystate, KeyboardState prevKeystate, GameTime gameTime)
    {
          
    }

    public virtual void Update(GameTime gameTime)
    { 

    }
    public void Draw(SpriteBatch spriteBatch, Vector2 camera)
    {
        
         spriteBatch.Draw(texture,new Rectangle(rect.X + (int)camera.X, rect.Y + (int)camera.Y, rect.Width, rect.Height), srect, SpriteColor);
    }

    public void Summon()
    {
        
    }
}