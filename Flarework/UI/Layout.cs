using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork.UI
{
    public class Layout : UIObject
    {
        public int Padding { get; set; }
        public enum Alignment { Vertical, Horizontal}
        public Alignment Aligned { get; set; }
        public List<UIObject> Group { get; set; }

        public Layout(Vector2 pos) : base(pos)
        {
            Group = new List<UIObject>();
        }

        public override void Update(GameTime time)
        {

        }

        public override void Draw(SpriteBatch sBatch)
        {
            foreach (UIObject u in Group)
                u.Draw(sBatch);
        }
    }
}
