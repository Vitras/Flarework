using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork.UI
{
    public class AnimatedButton : SimpleButton
    {

        public Animation HoverAnimation { get; set; }

        public AnimatedButton(Vector2 position, Animation animation = null, Texture2D inactive = null) : base(position, null, inactive)
        {
            HoverAnimation = animation;
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            if (State == ClickState.Hover)
                HoverAnimation.Update(time);
            else
                HoverAnimation.Reset();
        }

        public override void Draw(SpriteBatch sBatch)
        {
            if (State == ClickState.Pressed)
            {
                HoverAnimation.Color = Color.Gray;
                HoverAnimation.Draw(sBatch, Position, 0, 1);
            }
            else if (State == ClickState.Hover || State == ClickState.Released)
            {
                HoverAnimation.Color = Color.White;
                HoverAnimation.Draw(sBatch, Position, 0, 1);
            }
            else
            {
                sBatch.Draw(Inactive, ButtonBox, Color.White);
            }
        }
    }
}
