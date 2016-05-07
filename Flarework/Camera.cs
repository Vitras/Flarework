using System;
using Microsoft.Xna.Framework;
using FlareWork;
using Microsoft.Xna.Framework.Graphics;

public class Camera : GameObject
{
    public GameObject Focus { get; set; }
    public float MaxDistance { get; set; }
    public Matrix Transform { get; private set; }
    public float Rotation { get; set; }
    public float Zoom { get; set; }
    public Rectangle Bounds { get; set; }
    public bool Debug { get; set; }

    public Rectangle VisibleArea
    {
        get
        {
            var inverseViewMatrix = Matrix.Invert(Transform);
            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(Bounds.X, Bounds.Y), inverseViewMatrix);
            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            return new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }
    }

    private Matrix TransformMatrix
    {
        get {
            return
                Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom) *
                Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
        }
    }


    public Camera(Viewport viewport, Vector2 pos, string name = "Camera") : base(0, pos, name)
    {
        Bounds = viewport.Bounds;
        Zoom = 1f;
        Rotation = 0f;
        MaxDistance = 0f;
    }

    public override void Update(GameTime time)
    {
        base.Update(time);
        Transform = TransformMatrix;
        if(Focus != null)
        {
            FollowFocus();
        }
    }

    public void Draw(SpriteBatch sBatch)
    {
        if(Debug)
        {
            sBatch.Draw(TextureManager.Load("Player"), Position, Color.White);
        }
    }
    
    public void FollowFocus()
    {
        if((Focus.Position - Position).Length() > MaxDistance)
        {
            Position += Focus.Velocity;
        }
    }
}
