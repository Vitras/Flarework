using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlareWork
{
    public class SpriteObject : GameObject
    {
        public Sprite Sprite { get; set; }
        public bool Visible { get; set; }
        public float Rotation { get; set; }
        public int Layer { get; set; }
        public Rectangle BoundingBox { get; set; }

        public SpriteObject(int id, Vector2 position, string name, bool visible = true) : 
            base(id, position, name)
        {
            Visible = visible;   
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if(Visible && Sprite != null)
                Sprite.Draw(batch, Position, Rotation, Layer);
        }
    }
}
