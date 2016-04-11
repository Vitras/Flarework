using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace FlareWork.UI
{
    public class ColorEffect
    {
        Color Start { get; set; }
        Color End { get; set; }
        public bool Done { get; set; }
        public ColorEffect()
        {
            Start = Color.Black;
            End = Color.White;
        }

        public ColorEffect(Color start, Color end)
        {
            Start = start;
            End = end;
        }

        public Color Apply(GameTime gameTime, double duration, double current)
        {
                float ratio = (float)(current / duration);
                float deltaR = End.R - Start.R;
                float deltaG = End.G - Start.G;
                float deltaB = End.B - Start.B;
                float deltaA = End.A - Start.A;
                float finalR = (deltaR * ratio + Start.R) / 255;
                float finalG = (deltaG * ratio + Start.G) / 255;
                float finalB = (deltaB * ratio + Start.B) / 255;
                float finalA = (deltaA * ratio + Start.A) / 255;
            Color color = new Color(finalR, finalG, finalB, finalA);
                return new Color(finalR, finalG, finalB, finalA);
        }
    }
}
