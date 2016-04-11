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
    public class TextureManager
    {
        public Dictionary<string, Texture2D> textures;
        private ContentManager Content;

        public TextureManager(ContentManager content)
        {
            textures = new Dictionary<string, Texture2D>();
            this.Content = content;
        }

        public Texture2D Load(string name)
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
