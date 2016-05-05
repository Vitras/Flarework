using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork.UI
{
    public class UIObject
    {
        public Vector2 Position { get; set; }

        public UIObject(Vector2 pos)
        {
            Position = pos;
        }

        public virtual void Update(GameTime time)
        {

        }

        public virtual void Draw(SpriteBatch sBatch)
        {

        }
    }
}