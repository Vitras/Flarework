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
        private int _Frames { get { return Columns * Rows; } }
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
            FrameWidth = Game1.Textures.Load(sheet).Width / columns;
            FrameHeight = Game1.Textures.Load(sheet).Height / rows;
            _frame = 0;
            Loop = loop;
            IsPaused = false;
            Origin = Vector2.Zero;
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
            if (_currentTime < FrameTime)
            {
                _currentTime -= FrameTime;
                if (Loop)
                {
                    _frame = (_frame + 1) % _Frames;
                }
                else
                {
                    _frame = Math.Min(_frame + 1, _Frames);
                }
            }
        }
            
        public virtual void Draw(SpriteBatch batch, Vector2 position, float rotation, int layer)
        {
            Rectangle segment = new Rectangle(_Frames / Rows, _Frames % Columns, FrameWidth, FrameHeight);
            batch.Draw(Game1.Textures.Load(SheetName), position, segment, Color, rotation, Origin, Size, SpriteEffects.None, layer);
        }
    }
}
