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
        public string SheetName { get; set; }
        public float FrameTime { get; set; }
        public bool Loop { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public int Rows { get; set;}
        public int Columns { get; set; }
        public bool IsPaused { get; set; }
        public Color Color { get; set; }
        public Vector2 Origin { get; set; }
        private int _frames { get { return Columns * Rows; } }
        private int _frame;
        private float _currentTime;
        public float Size { get; set; }

        public Animation(string sheet, float frameTime, int rows, int columns, bool loop = false)
        {
            SheetName = sheet;
            FrameTime = frameTime;
            Rows = rows;
            Columns = columns;
            Color = Color.White;
            FrameWidth = TextureManager.Load(sheet).Width / columns;
            FrameHeight = TextureManager.Load(sheet).Height / rows;
            _frame = 0;
            Loop = loop;
            IsPaused = false;
            Origin = Vector2.Zero;
            Size = 1.0f;
        }

        public virtual void Reset()
        {
            _frame = 0;
            _currentTime = 0;
        }

        public virtual void Update(GameTime time)
        {
            if (IsPaused)
                return;
            _currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            if (_currentTime > FrameTime)
            {
                _currentTime -= FrameTime;
                if (Loop)
                {
                    _frame = (_frame + 1) % _frames;
                }
                else
                {
                    _frame = Math.Min(_frame + 1, _frames);
                }
            }
        }
            
        public virtual void Draw(SpriteBatch batch, Vector2 position, float rotation, int layer)
        {
            Rectangle segment = new Rectangle(_frame % Columns * FrameWidth, _frame % Rows * FrameHeight, FrameWidth, FrameHeight);
            batch.Draw(TextureManager.Load(SheetName), position, segment, Color, rotation, Origin, Size, SpriteEffects.None, layer);
        }
    }
}
