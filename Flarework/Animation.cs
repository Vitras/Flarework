using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork
{
    public class Animation
    {
        public string Name;
        public Texture2D Sheet { get; set; }
        public float FrameTime { get; set; }
        public bool Loop { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public int Rows { get; set;}
        public int Columns { get; set; }
        private int _Frames { get { return Columns * Rows; } }
        private int _frame;
        private float _currentTime;

        public Animation(string name, Texture2D sheet, float frameTime, int rows, int columns, bool loop = false)
        {
            Name = name;
            Sheet = sheet;
            FrameTime = frameTime;
            Rows = rows;
            Columns = columns;
            FrameWidth = Sheet.Width / columns;
            FrameHeight = Sheet.Height / rows;
            _frame = 0;
            Loop = loop;
        }

        public virtual void Reset()
        {
            _frame = 0;
            _currentTime = 0;
        }

        public virtual void Update(GameTime time)
        {
            _currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            if(_currentTime < FrameTime)
            {
                _currentTime -= FrameTime;

            }
        }
    }
}
