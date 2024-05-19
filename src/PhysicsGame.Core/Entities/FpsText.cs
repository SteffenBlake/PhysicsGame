using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PhysicsGame.Core.Abstractions;

namespace PhysicsGame.Core.Entities;

public class FpsText : TextEntity, IProgressable
{
    public FpsText(float gameScale, SpriteFont font) : base(gameScale, font)
    {
        Layer = 1.0f;
    }

    public void Update(float delta, Vector2 gameBounds)
    {
        var fps = 1 / delta;
        Text = $"{fps:0.0} FPS";
    }
}
