using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FlareWork
{
    static class InputManager
    {
        private static KeyboardState kbCurrent;
        private static KeyboardState kbPrevious;
        private static GamePadState gpCurrent;
        private static GamePadState gpPrevious;
        private static MouseState mCurrent;
        private static MouseState mPrevious;

        public static bool IsKeyPressed(Keys k)
        {
            return kbPrevious.IsKeyUp(k) && kbCurrent.IsKeyDown(k);
        }

        public static bool IsKeyDown(Keys k)
        {
            return kbCurrent.IsKeyDown(k);
        }

        public static bool IsKeyReleased(Keys k)
        {
            return kbPrevious.IsKeyDown(k) && kbCurrent.IsKeyUp(k);
        }

        public static bool IsKeyUp(Keys k)
        {
            return kbCurrent.IsKeyUp(k);
        }

        public static bool IsButtonPressed(Buttons b)
        {
            return gpPrevious.IsButtonUp(b) && gpCurrent.IsButtonDown(b);
        }

        public static bool IsButtonDown(Buttons b)
        {
            return gpCurrent.IsButtonDown(b);
        }

        public static bool IsButtonReleased(Buttons b)
        {
            return gpPrevious.IsButtonDown(b) && gpCurrent.IsButtonUp(b);
        }

        public static bool IsButtonUp(Buttons b)
        {
            return gpCurrent.IsButtonUp(b);
        }

        public static void Update()
        {
            kbPrevious = kbCurrent;
            gpPrevious = gpCurrent;
            mPrevious = mCurrent;
            kbCurrent = Keyboard.GetState();
            gpCurrent = GamePad.GetState(0);
            mCurrent = Mouse.GetState();
        }
    }
}
