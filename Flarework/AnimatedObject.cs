using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork
{
    public class AnimatedObject : GameObject
    {
        public Dictionary<String, Animation> Animations;
        public Animation Current;
        public bool Visible { get; set; }
        public float Rotation { get; set; }
        public int Layer { get; set; }

        public AnimatedObject(int id, Vector2 position, string name, bool visible = true) : base(id, position, name)
        {
            Animations = new Dictionary<string, Animation>();
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            if (Current != null)
            {
                Current.Update(time);
            }
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (Visible && Current != null)
                Current.Draw(batch, Position, Rotation, Layer);
        }
    }
}
