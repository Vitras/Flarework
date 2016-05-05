using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlareWork
{
    public static class TextureManager
    {
        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public static ContentManager Content;

        public static Texture2D Load(string name)
        {
            if (textures.ContainsKey(name))
                return textures[name];
            else
            {
                Texture2D texture = Content.Load<Texture2D>("Texture2D/" + name);
                textures.Add(name, texture);
                return textures[name];
            }
        }


    }
}
