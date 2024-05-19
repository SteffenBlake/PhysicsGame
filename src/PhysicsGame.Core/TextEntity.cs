using Apos.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PhysicsGame.Core.Abstractions;

namespace PhysicsGame.Core;

public class TextEntity(
    float gameScale, SpriteFont font
)
    : Entity(gameScale), IRenderable
{
    public string Text { get; set; } = "";

    public Vector2 Origin { get; set; } = new();

    public float Scale { get; set; } = 1.0f;

    public SpriteEffects Effects { get; set; } = SpriteEffects.None;

    public float Layer { get; set; } = 1.0f;

    private SpriteFont Font { get; } = font;

    public virtual void Draw(SpriteBatch spriteBatch, ShapeBatch _)
    {
        spriteBatch.DrawString(
            spriteFont: Font,
            text: Text,
            position: ScaledPos,
            color: Color.White,
            rotation: Rotation,
            origin: Origin,
            scale: Scale,
            effects: Effects,
            layerDepth: Layer
        );
    }
}
