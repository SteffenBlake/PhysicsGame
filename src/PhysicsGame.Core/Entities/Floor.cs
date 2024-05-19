using Apos.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PhysicsGame.Core.Abstractions;

namespace PhysicsGame.Core.Entities;

public class Floor : Entity, IRenderable
{
    private Vector2 Size { get; }
    public Floor(float gameScale) : base(gameScale)
    {
        Pos = new(5.0f, 2.0f);
        Size = new Vector2(2.0f, 1.0f) * gameScale;
    }

    public void Draw(SpriteBatch _, ShapeBatch shapes)
    {
        shapes.DrawRectangle(ScaledPos, Size, Color.LightGray, Color.DarkGray);
    }
}
