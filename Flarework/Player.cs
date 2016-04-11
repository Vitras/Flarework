using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlareWork
{
    public class Player : SpriteObject
    {
        public PlayerShield Left { get; set; }
        public PlayerShield Right { get; set; }
        public PlayerShield Up { get; set; }
        public PlayerShield Down { get; set; }
        public float ShieldDistance { get; set; }
        public float ShieldRotation { get; set; }
        public float RotationSpeed { get; set; }
        public float MovementSpeed { get; set; }
        
        public float ShieldOffset { get { return (float)Math.PI; } }
        public Player(int id, Vector2 position, string name = "Player") : base(id, position, name)
        {
            Sprite = new Sprite("Player", Vector2.Zero);
            Sprite.Origin = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            ShieldDistance = 100;
            ShieldRotation = (float)Math.PI/2;
            RotationSpeed = 7.5f;
            MovementSpeed = 150;
            Right = new PlayerShield(2, new Vector2((float)Math.Cos(ShieldRotation), (float)Math.Sin(ShieldRotation)) * ShieldDistance + Position);
            Left = new PlayerShield(3, new Vector2((float)Math.Cos(ShieldRotation + ShieldOffset), (float)Math.Sin(ShieldRotation + ShieldOffset)) * ShieldDistance + Position);
            Up = new PlayerShield(4, new Vector2((float)Math.Cos(ShieldRotation + ShieldOffset/2), (float)Math.Sin(ShieldRotation + ShieldOffset/2)) * ShieldDistance + Position);
            Down = new PlayerShield(5, new Vector2((float)Math.Cos(ShieldRotation + ShieldOffset * 1.5f), (float)Math.Sin(ShieldRotation + ShieldOffset * 1.5f)) * ShieldDistance + Position);
            Sprite.Color = Color.Black;
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            float dRotation = 0;
            float dx = 0;
            float dy = 0;
            if (InputManager.IsKeyDown(Keys.Left))
                dx -= 1;
            if (InputManager.IsKeyDown(Keys.Right))
                dx += 1;
            if (InputManager.IsKeyDown(Keys.Up))
                dy -= 1;
            if (InputManager.IsKeyDown(Keys.Down))
                dy += 1;
            if (dx != 0 || dy != 0)
            {
            }
            if(InputManager.IsKeyDown(Keys.X))
            {
                dRotation -= 1;
            }
            if(InputManager.IsKeyDown(Keys.C))
            {
                dRotation += 1;
            }
            if (dx != 0 || dy != 0 || dRotation != 0)
            {
                Position += new Vector2(dx, dy) * MovementSpeed * (float)time.ElapsedGameTime.TotalSeconds;
                ShieldRotation += dRotation * RotationSpeed * (float)time.ElapsedGameTime.TotalSeconds;
                if (ShieldRotation > Math.PI * 2)
                    ShieldRotation -= (float)Math.PI * 2;
                else if (ShieldRotation < -360)
                    ShieldRotation += (float)Math.PI * 2;
                Right.Position = new Vector2((float)Math.Cos(ShieldRotation), (float)Math.Sin(ShieldRotation)) * ShieldDistance + Position;
                Left.Position = new Vector2((float)Math.Cos(ShieldRotation + ShieldOffset), (float)Math.Sin(ShieldRotation + ShieldOffset)) * ShieldDistance + Position;
                Up.Position = new Vector2((float)Math.Cos(ShieldRotation + ShieldOffset / 2), (float)Math.Sin(ShieldRotation + ShieldOffset / 2)) * ShieldDistance + Position;
                Down.Position = new Vector2((float)Math.Cos(ShieldRotation + ShieldOffset * 1.5f), (float)Math.Sin(ShieldRotation + ShieldOffset * 1.5f)) * ShieldDistance + Position;
            }
            Right.Update(time);
            Left.Update(time);
            Up.Update(time);
            Down.Update(time);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            Left.Draw(batch);
            Right.Draw(batch);
            Up.Draw(batch);
            Down.Draw(batch);
        }
    }
}
