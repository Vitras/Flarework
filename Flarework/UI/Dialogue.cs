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
    public class Dialogue
    {
        string text;
        string current;
        int nextletter;
        Vector2 position;
        Vector2 baseoffset;
        SpriteFont textFont;
        LetterEffect effect;
        public bool TextDone { get { return effect.EffectDone && text.Length == nextletter; } }

        public Dialogue(string text, Vector2 position, SpriteFont sFont)
        {
            this.text = text;
            this.current = "";
            this.position = position;
            textFont = sFont;
            Initialize(0.25);
        }
        public void Reset(string text)
        {
            this.text = text;
            this.current = "";
            Initialize(0.25);
        }
        public void Initialize(double effectTime)
        {
            nextletter = 0;
            baseoffset = textFont.MeasureString(current);
            effect = new LetterEffect(effectTime, text[nextletter],
                new ColorEffect(new Color(Color.Orange, 0f), new Color(Color.Orange, 1f)));
            effect.Destination = position + baseoffset;
        }
        public void Update(GameTime gameTime)
        {
            effect.Update(gameTime);
            if (!TextDone)
            {
                if(effect.EffectDone)
                {
                    current += text[nextletter];
                    Vector2 newoffset = textFont.MeasureString(current);
                    nextletter++;
                    if (TextDone)                        
                        return;
                    effect.ResetLetter(text[nextletter]);
                    effect.Destination = new Vector2(position.X + newoffset.X, position.Y + baseoffset.Y);
                }
            }
        }
        public void Draw(SpriteBatch sBatch)
        {

            sBatch.DrawString(textFont, current, position, Color.Orange);
            if (!TextDone)
            {
                effect.Draw(sBatch, textFont);
            }
        }
    }
}
