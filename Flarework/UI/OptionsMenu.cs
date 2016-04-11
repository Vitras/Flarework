using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlareWork.UI
{
    public class OptionsMenu : Menu
    {
        public NamedSlider MasterSlider;
        public NamedSlider SFXSlider;
        public NamedSlider VoiceSlider;
        public NamedSlider AmbientSlider;
        SpriteFont GeneralFont;
        public OptionsMenu(Dictionary<string, Texture2D> textures, Dictionary<string, SpriteFont> fonts)
            :base()
         {
            GeneralFont = fonts["general"];            
            Initialize(textures, fonts);
        }
        public void Initialize(Dictionary<string, Texture2D> textures, Dictionary<string, SpriteFont> fonts)
        {
            MasterSlider = new NamedSlider("Master Volume", new Vector2(100, 100), fonts, textures);
            int offset = MasterSlider.slider.End.Height + 40;
            SFXSlider = new NamedSlider("SFX Volume", new Vector2(100, 100 + offset), fonts, textures);
            VoiceSlider = new NamedSlider("Voice Volume", new Vector2(100, 100 + offset * 2), fonts, textures);
            AmbientSlider = new NamedSlider("Ambient Volume", new Vector2(100, 100 + offset * 3), fonts, textures);
        }
        public override bool Update(Stack<Menu> Menus, Dictionary<string, Texture2D> textures,
            Dictionary<string, SpriteFont> fonts, MouseState curMouse, MouseState preMouse)
        {
            MasterSlider.Update(curMouse, preMouse);
            SFXSlider.Update(curMouse, preMouse);
            VoiceSlider.Update(curMouse, preMouse);
            AmbientSlider.Update(curMouse, preMouse);
            return false;
        }
        public override void Draw(SpriteBatch sBatch)
        {
            MasterSlider.Draw(sBatch);
            SFXSlider.Draw(sBatch);
            VoiceSlider.Draw(sBatch);
            AmbientSlider.Draw(sBatch);
        }
    }
}
