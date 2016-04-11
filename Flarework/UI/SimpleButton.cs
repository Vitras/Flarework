using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlareWork.UI
{
    public class SimpleButton
    {
        protected Texture2D Inactive;
        protected Texture2D Hover;
        protected Vector2 Position;
        protected ClickState State;
        public bool Triggered { get { return State == ClickState.Released; } }
        public Rectangle ButtonBox { get { return new Rectangle((int)Position.X, (int)Position.Y, Hover.Width, Hover.Height); } }
        public SimpleButton(Vector2 position, Texture2D hover, Texture2D inactive)
        {
            Inactive = inactive;
            Hover = hover;
            Position = position;
        }
        public virtual void OnMouseover()
        {

        }
        public virtual void OnRelease()
        {

        }

        public virtual void Update(MouseState curMouse, MouseState preMouse)
        {
            if (ButtonBox.Contains(curMouse.Position))
            {
                if (curMouse.LeftButton == ButtonState.Pressed)
                {
                    State = ClickState.Pressed;
                }
                else if (State == ClickState.Pressed && curMouse.LeftButton == ButtonState.Released)
                {
                    State = ClickState.Released;
                }
                else
                {
                    State = ClickState.Hover;
                }
            }
            else
            {
                State = ClickState.Inactive;
            }
        }
        public virtual void Draw(SpriteBatch sBatch)
        {
            if(State == ClickState.Pressed)
            {
                sBatch.Draw(Hover, ButtonBox, new Color(Color.Gray, 1.0f));
            }
            else if(State == ClickState.Hover || State == ClickState.Released)
            {
                sBatch.Draw(Hover, ButtonBox, Color.White);
            }
            else
            {
                sBatch.Draw(Inactive, ButtonBox, Color.White);
            }
        }
        public enum ClickState { Inactive, Pressed, Hover, Released };
    }
}
