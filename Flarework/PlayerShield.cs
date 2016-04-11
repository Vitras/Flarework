using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlareWork
{
    public class PlayerShield : SpriteObject
    {
        Enemy test;
        public PlayerShield(int id, Vector2 position, string name = "Shield") : base(id, position, name)
        {
            Sprite = new Sprite("Shield", Vector2.Zero);
            Sprite.Color = Color.MonoGameOrange;
            Sprite.Origin = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
            test = new Enemy(10, Position + new Vector2(0, 50));
        }       

        public override void Update(GameTime time)
        {
            base.Update(time);
            BoundingBox = new Rectangle((int)(Position.X - Sprite.Origin.X), (int)(Position.Y - Sprite.Origin.Y), (int)Sprite.Width, (int)Sprite.Height);
            test.Update(time);
            if (BoundingBox.Intersects(test.BoundingBox))
            {
                Sprite.Color = Color.Red;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            test.Draw(batch);
        }
    }
}
