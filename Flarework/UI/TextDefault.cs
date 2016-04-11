using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork.UI
{
    public class TextDefault
    {
        public bool IsDone { get; private set; }
        string text;
        string current;
        int nextletter;
        double letterTime, previousLetterTime;
        Vector2 position;
        SpriteFont textFont;

        public TextDefault(string text, Vector2 position, SpriteFont sFont)
        {
            this.text = text;
            this.current = "";    
            this.position = position;
            textFont = sFont;
            Initialize();
        }
        public void ResetBox(string text)
        {
            this.text = text;
            this.current = "";
            Initialize();
        }
        public void Initialize()
        {
            IsDone = false;
            nextletter = 0;
            letterTime = 0.20;
            previousLetterTime = letterTime;
        }
        public void Update(GameTime gameTime)
        {
            if(!IsDone)
            {
                previousLetterTime += gameTime.ElapsedGameTime.TotalSeconds;
                if(previousLetterTime > letterTime)
                {
                    current += text[nextletter];
                    previousLetterTime = 0;
                    nextletter++;
                    IsDone = nextletter == text.Length;
                }
            }
        }
        public void Draw(SpriteBatch sBatch)
        {
            sBatch.DrawString(textFont, current, position, Color.White);
        }
    }
}
