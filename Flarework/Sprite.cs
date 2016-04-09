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
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Size { get; set; }
       

        public Sprite(Texture2D texture, Vector2 origin)
        {
            Texture = texture;
            Color = Color.White;
            Origin = origin;
            Size = new Vector2(1, 1);   
        }
    }
}
