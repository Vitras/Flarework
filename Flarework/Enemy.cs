using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork
{
    public class Enemy : SpriteObject
    {
        float switchTime;
        float currentTime;
        public Enemy(int id, Vector2 position, string name = "Enemy") : base(id, position, name)
        {
            Sprite = new Sprite("Enemy", Vector2.Zero);
            Sprite.Origin = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            switchTime = 3;
            currentTime = 0;
            Velocity = new Vector2(3, 0);
        }       

        public override void Update(GameTime time)
        {
            base.Update(time);
            BoundingBox = new Rectangle((int)(Position.X - Sprite.Origin.X), (int)(Position.Y - Sprite.Origin.Y), (int)Sprite.Width, (int)Sprite.Height);
            currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            if(currentTime > switchTime)
            {
                currentTime -= switchTime;
                Velocity = -Velocity;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
