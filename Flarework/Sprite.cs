using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork
{
    public class Sprite
    {
        public string TextureName { get; set; }
        public Color Color { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Size { get; set; }
        public Texture2D Texture { get { return Game1.Textures.Load(TextureName); } }
        public float Width { get { return Texture.Width * Size.X; } }
        public float Height { get { return Texture.Height * Size.Y; } }

        public Sprite(string texture, Vector2 origin)
        {
            TextureName = texture;
            Color = Color.White;
            Origin = origin;
            Size = new Vector2(1, 1);
        }

        public virtual void Draw(SpriteBatch batch, Vector2 position, float rotation = 0.0f, int layer = 0)
        {
            batch.Draw(Texture, position, null, Color, rotation, Origin, Size, SpriteEffects.None, layer);            
        }
    }
}
