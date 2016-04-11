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
    public class LetterEffect
    {
        public Vector2 Destination { get; set; }
        public Vector2 DrawPosition { get; set; }
        public char EffectLetter { get; set; }
        public bool EffectDone { get { return effectCurrent >= effectDuration; } }
        protected double effectDuration;
        protected double effectCurrent;
        protected Color color;
        ColorEffect CEffect;

        public LetterEffect(double duration, char letter)
        {
            effectDuration = duration;
            EffectLetter = letter;
            Initialize();
        }

        public LetterEffect(double duration, char letter, ColorEffect colorEffect)
        {
            effectDuration = duration;
            EffectLetter = letter;
            CEffect = colorEffect;
            Initialize();
        }

        public virtual void ResetLetter(char Letter)
        {
            EffectLetter = Letter;
            Initialize();
        }
        public virtual void Initialize()
        {
            effectCurrent = 0;
            color = new Color(Color.Black, 1.0f);
            DrawPosition = new Vector2(Destination.X + 50, Destination.Y - 80);
        }
        public virtual void Update(GameTime gameTime)
        {

           effectCurrent = Math.Min(effectCurrent + gameTime.ElapsedGameTime.TotalSeconds, effectDuration);
            if (CEffect != null)
                color = CEffect.Apply(gameTime, effectDuration, effectCurrent);
        }

        public virtual void Draw(SpriteBatch sBatch, SpriteFont sFont)
        {
            sBatch.DrawString(sFont, new string(EffectLetter, 1), DrawPosition, color);
        }
    }
}
