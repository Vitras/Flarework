﻿using Microsoft.Xna.Framework;

namespace FlareWork
{
    public class GameObject
    {
        
        public int ID { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 LocalPosition { get; set; }
        public GameObject Parent { get; set; }
        public string Name { get; set; }

        public GameObject(int id, Vector2 position, string name)
        {
            Position = position;
            Velocity = Vector2.Zero;
            Name = name;
            ID = id;
        }
        public virtual void Update(GameTime time)
        {
            Position += Velocity;
            LocalPosition = Parent != null ? Position - Parent.Position : Vector2.Zero;
        }
    }
}
