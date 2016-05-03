using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlareWork.UI
{
    public class Slider
    {
        SimpleButton LeftButton;
        SimpleButton RightButton;
        int Scale;
        int CurrentVolume;
        int offset;
        Vector2 Position;
        public Texture2D End, Bar, Dot;
        public Slider(Vector2 position, Dictionary<string, Texture2D> textures)
        {
            offset = 15;
            Scale = 10;
            CurrentVolume = 5;
            Position = position;
            Texture2D[] left = new Texture2D[2] { textures["BasicLeftButtonHover"], textures["BasicLeftButtonInactive"] };
            Texture2D[] right = new Texture2D[2] { textures["BasicRightButtonHover"], textures["BasicRightButtonInactive"] };
            End = textures["BasicSliderEnd"];
            Bar = textures["BasicSliderBar"];
            Dot = textures["BasicSliderDot"];
            LeftButton = new SimpleButton(new Vector2(Position.X, Position.Y - left[0].Height / 2 + End.Height / 2), left[0], left[1]);
            RightButton = new SimpleButton(new Vector2(Position.X + End.Width * 2 + (4 + Bar.Width) *
                Scale + offset * 2 + left[0].Width, Position.Y - left[0].Height / 2 + End.Height / 2), right[0], right[1]);
        }
        public virtual void Update(MouseState curMouseState, MouseState preMouseState)
        {
            LeftButton.Update();
            RightButton.Update();
            if (LeftButton.Triggered)
            {
                CurrentVolume = Math.Max(CurrentVolume - 1, 0);
            }
            else if(RightButton.Triggered)
            {
                CurrentVolume = Math.Min(CurrentVolume + 1, Scale);
            }
        }
        public virtual void Draw(SpriteBatch sBatch)
        {
            LeftButton.Draw(sBatch);
            RightButton.Draw(sBatch);
            int x = 0;
            float finaloffset = Position.X + offset + LeftButton.ButtonBox.Width;
            sBatch.Draw(End, new Vector2(finaloffset, Position.Y), Color.White);
            while(x < CurrentVolume)
            {
                sBatch.Draw(Bar, new Vector2(finaloffset + End.Width + 4 + 
                    x * (Bar.Width + 4), Position.Y + End.Height / 2 - Bar.Height / 2), Color.White);
                x++;             
            }
            while(x < Scale)
            {
                sBatch.Draw(Dot, new Vector2(finaloffset + End.Width + 4  + 
                    x * (Bar.Width + 4), Position.Y + End.Height / 2 -  Dot.Height / 2), Color.White);
                x++;
            }
            sBatch.Draw(End, new Vector2(finaloffset + End.Width + 4 + Scale * (Bar.Width + 4), Position.Y), Color.White);
        }
    }
}
