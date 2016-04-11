using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FlareWork.UI
{
    public class NamedSlider
    {
        string Name;
        SpriteFont Font;
        Vector2 Position;
        public Slider slider;
        public NamedSlider(string name, Vector2 position, Dictionary<string, SpriteFont> Fonts, Dictionary<string, Texture2D> textures)
        {
            Position = position;            
            Name = name;
            Font = Fonts["general"];
            Vector2 FontVector = Font.MeasureString(Name);
            Vector2 SliderSize = new Vector2(textures["BasicSliderEnd"].Width, textures["BasicSliderEnd"].Height); 
            slider = new Slider(new Vector2(Position.X + FontVector.X + 30, 
                Position.Y - SliderSize.Y / 2 + FontVector.Y / 2), textures);
        } 
        public void Update(MouseState curMouseState, MouseState preMouseState)
        {
            slider.Update(curMouseState, preMouseState);
        }
        public void Draw(SpriteBatch sBatch)
        {
            sBatch.DrawString(Font, Name, Position, Color.White);
            slider.Draw(sBatch);
        }
    }
}
