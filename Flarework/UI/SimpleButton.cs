using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlareWork.UI
{
    public delegate void ButtonClick();
    public class SimpleButton
    {
        protected Texture2D Inactive;
        protected Texture2D Hover;
        protected Vector2 Position;
        protected ClickState State;
        public bool Triggered { get { return State == ClickState.Released; } }
        public Rectangle ButtonBox { get { return new Rectangle((int)Position.X, (int)Position.Y, Hover.Width, Hover.Height); } }
        public event ButtonClick OnClick;
        public SimpleButton(Vector2 position, Texture2D hover, Texture2D inactive)
        {
            Inactive = inactive;
            Hover = hover;
            Position = position;
        }
        public virtual void OnMouseover()
        {

        }

        public virtual void Update()
        {
            if (ButtonBox.Contains(InputManager.GetMousePosition()))
            {
                if (InputManager.IsMouseDown(0))
                {
                    State = ClickState.Pressed;
                }
                else if (InputManager.IsMouseReleased(0))
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
            if (State == ClickState.Released)
                OnClick.Invoke();
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
