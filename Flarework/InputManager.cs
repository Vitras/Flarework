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

        private static ButtonState? GetMouseButton(int button, bool cur = true)
        {
            if (cur)
                switch (button)
                {
                    case 0: return mCurrent.LeftButton;
                    case 1: return mCurrent.RightButton;
                    case 2: return mCurrent.MiddleButton;
                    default: return null;
                }
            else
                switch (button)
                {
                    case 0: return mPrevious.LeftButton;
                    case 1: return mPrevious.RightButton;
                    case 2: return mPrevious.MiddleButton;
                    default: return null;
                }
        }

        public static bool IsMouseDown(int button)
        {
            ButtonState? current = GetMouseButton(button);
            if (current.HasValue)
                return current == ButtonState.Pressed;
            else
                return false;
        }

        public static bool IsMouseUp(int button)
        {
            ButtonState? current = GetMouseButton(button);
            if (current.HasValue)
                return current == ButtonState.Released;
            else
                return true;
        }

        public static bool IsMouseReleased(int button)
        {
            ButtonState? current = GetMouseButton(button);
            ButtonState? previous = GetMouseButton(button, false);
            if (current.HasValue && previous.HasValue)
                return current == ButtonState.Released && previous == ButtonState.Pressed;
            else
                return false;
        }

        public static bool IsMousePressed(int button)
        {
            ButtonState? current = GetMouseButton(button);
            ButtonState? previous = GetMouseButton(button, false);
            if (current.HasValue && previous.HasValue)
                return current == ButtonState.Pressed && previous == ButtonState.Released;
            else
                return false;
        }

        public static Point GetMousePosition()
        {
            return mCurrent.Position;
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
