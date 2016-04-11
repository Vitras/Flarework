using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork.UI
{
    public class NamedButton : SimpleButton
    {
        public string Name { get; set; }
        Vector2 TextPosition;
        SpriteFont Font;
        
        public NamedButton(string name, SpriteFont font, Vector2 Position, Texture2D hover, Texture2D inactive)
            : base(Position, hover, inactive)
        {
            Font = font;
            Name = name;
            Vector2 FontVector = Font.MeasureString(Name);
            TextPosition = new Vector2(Position.X + (-FontVector.X + Hover.Width) / 2, Position.Y + (-FontVector.Y + Hover.Height) / 2);
        }
        public override void Draw(SpriteBatch sBatch)
        {
            base.Draw(sBatch);
            sBatch.DrawString(Font, Name, TextPosition, Color.White);
        }
    }

}
