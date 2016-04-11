using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace FlareWork.UI
{
    public class Menu
    {
        public Menu()
        {
        }
        public virtual bool Update(Stack<Menu> Menus, Dictionary<string, Texture2D> textures, 
            Dictionary<string, SpriteFont> Fonts, MouseState curMouse, MouseState preMouse)
        {
            return false;
        }
        public virtual void Draw(SpriteBatch sBatch)
        {
        }
    }
}
