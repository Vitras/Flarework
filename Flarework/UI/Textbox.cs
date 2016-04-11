using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace FlareWork.UI
{
    public class Textbox
    {
        Dialogue Dialogue;
        Texture2D Background;
        Vector2 Position;
        Texture2D FinishSprite;
        SoundEffect DialogueEnd;
        SoundEffect DialogueStart;
        SoundEffect DialogueNext;
        double NextDialogueTimer;
        double BaseDialogueTimer;
        String[] AllDialogue;
        int Current;
        bool DialogueDone;
        bool AutoAdvance;
        
        public Textbox(Vector2 position, SpriteFont sFont, ContentManager content)
        {
            Position = position;
            Background = content.Load<Texture2D>("Images/genericbackground");
            FinishSprite = content.Load<Texture2D>("Images/defaulttextboxsprite");
            DialogueNext = content.Load<SoundEffect>("SFX/TextboxNext");
            DialogueStart = content.Load<SoundEffect>("SFX/TextboxOpen");
            DialogueEnd = content.Load<SoundEffect>("SFX/TextboxClose");
            Initialize(sFont);            
        }
        public void TryhardDialogue()
        {
            AllDialogue = new string[10] {"Hello everybody, I'm a line of text!",
            "But who honestly cares about such little things?",
            "What I really want to do is watch you suffer as you sleep...",
            "That is just the kind of evil dialogue I actually am.",
            "In the end, we will all.... OH LOOK, A BUTTERFLY!",
            "I must examine it. I must.. for it is the key to my master plan!",
            "Do not move an inch, you mortal fleshling! I will show you my powers!",
            "A textbox is more than just a display of your stupid strings, you arrogant fool!",
            "You shall witness my powers firsthand once I catch this infernal bug...",
            "No, wait, what are you doing, don't end the dialogue, no, wait, noooooo!"};
        }
        public void Initialize(SpriteFont sFont)
        {
            TryhardDialogue();
            AutoAdvance = true;
            BaseDialogueTimer = 2;
            NextDialogueTimer = 0;
            Vector2 textOffset = new Vector2(20, 20);
            Current = 0;
            Dialogue = new Dialogue(AllDialogue[Current], Position + textOffset, sFont);
            DialogueDone = false;

        }
        public void NextDialogue()
        {
            NextDialogueTimer = 0;
            Current++;
            Dialogue.Reset(AllDialogue[Current]);
        }
        public void CloseBox()
        {
        }
        public void Input()
        {
            
            if (InputManager.IsKeyPressed(Keys.Space))
            {
                if (!DialogueDone)
                    NextDialogue();
                else
                    CloseBox();
            }
        }
        public void Update(GameTime gameTime)
        {
            Dialogue.Update(gameTime);            
            if(DialogueDone)
            {
                Input();
            }
            else if (Dialogue.TextDone)
            {
                if (Current < AllDialogue.Length - 1)
                {
                    if (AutoAdvance)
                    {
                        NextDialogueTimer += gameTime.ElapsedGameTime.TotalSeconds;
                        if (NextDialogueTimer > BaseDialogueTimer)
                            NextDialogue();
                    }
                    Input();
                }
                else if (!DialogueDone)
                {
                    DialogueDone = true;
                }
            }
        }
        public void Draw(SpriteBatch sBatch)
        {           
            sBatch.Draw(Background, Position, Color.DarkBlue);
            if (Dialogue.TextDone)
            {
                sBatch.Draw(FinishSprite, Position + new Vector2(750, 150));
            }
            Dialogue.Draw(sBatch);           
        }
    }
}
