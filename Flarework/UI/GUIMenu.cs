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
    public class GUIMenu : Menu
    {
        public NamedButton NewGame;
        public NamedButton Continue;
        public NamedButton Options;
        public NamedButton Extras;
        public NamedButton Exit;
        public NamedButton SoundTest;
        public NamedButton Cinematics;
        public NamedButton Credits;
        public NamedButton Back;
        MenuState State; 
        SpriteFont GeneralFont;
        public GUIMenu(Dictionary<string, Texture2D> textures, Dictionary<string, SpriteFont> Fonts)
            :base()
        {
            GeneralFont = Fonts["general"];
            Initialize(textures);
        }
        public void Initialize(Dictionary<string, Texture2D> textures)
        {
            State = MenuState.Normal;
            Texture2D hover = textures["BasicButtonHover"];
            Texture2D inactive = textures["BasicButtonInactive"];
            int offset = hover.Height + 30;
            NewGame = new NamedButton("New Game", GeneralFont, new Vector2(40, 20), hover, inactive);
            Continue = new NamedButton("Continue", GeneralFont, new Vector2(40, 20 + offset), hover, inactive);
            Options = new NamedButton("Options", GeneralFont, new Vector2(40, 20 + offset * 2), hover, inactive);
            Extras = new NamedButton("Extras", GeneralFont, new Vector2(40, 20 + offset * 3), hover, inactive);
            Exit = new NamedButton("Exit", GeneralFont, new Vector2(40, 20 + offset * 4), hover, inactive);
            SoundTest = new NamedButton("SoundTest", GeneralFont, new Vector2(70 + hover.Width, 20), hover, inactive);
            Cinematics = new NamedButton("Cinematics", GeneralFont, new Vector2(70 + hover.Width, 20 + offset), hover, inactive);
            Credits = new NamedButton("Credits", GeneralFont, new Vector2(70 + hover.Width, 20 + offset * 2), hover, inactive);
            Back = new NamedButton("Back", GeneralFont, new Vector2(70 + hover.Width, 20 + offset * 3), hover, inactive);
        }
        public override bool Update(Stack<Menu> Menus, Dictionary<string, Texture2D> textures,
            Dictionary<string, SpriteFont> fonts, MouseState curMouse, MouseState preMouse)
        {
            if (State == MenuState.Normal)
            {
                NewGame.Update(curMouse, preMouse);
                Continue.Update(curMouse, preMouse);
                Options.Update(curMouse, preMouse);
                Extras.Update(curMouse, preMouse);
                Exit.Update(curMouse, preMouse);
                if (Options.Triggered)
                {
                    Menus.Push(new OptionsMenu(textures, fonts));
                }
                else if (Extras.Triggered)
                {
                    State = MenuState.Extras;
                }
                else if (Exit.Triggered)
                {
                    return true;
                }
            }
            else
            {
                if (State == MenuState.Extras)
                {
                    SoundTest.Update(curMouse, preMouse);
                    Cinematics.Update(curMouse, preMouse);
                    Credits.Update(curMouse, preMouse);
                }
                Back.Update(curMouse, preMouse);
                if(Back.Triggered)
                {
                    State = MenuState.Normal;
                }
            }
            return false;
        }
        public override void Draw(SpriteBatch sBatch)
        {
            if(State != MenuState.Normal)
            {
                if (State == MenuState.Extras)
                {
                    SoundTest.Draw(sBatch);
                    Cinematics.Draw(sBatch);
                    Credits.Draw(sBatch);
                }
                Back.Draw(sBatch);
            }
            NewGame.Draw(sBatch);
            Continue.Draw(sBatch);
            Options.Draw(sBatch);
            Extras.Draw(sBatch);
            Exit.Draw(sBatch);
        }
        private enum MenuState { Normal, Extras, Options }
    }
}
