using Apos.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PhysicsGame.Core.Abstractions;
using PhysicsGame.Core.Animations;

namespace PhysicsGame.Core;

public class SpriteEntity(
    float gameScale, Texture2D texture, SpriteAnimation animation
)
    : Entity(gameScale), IRenderable, IProgressable
{
    public float Scale { get; set; } = 1.0f;
    public Vector2 Origin { get; set; } = new();

    private Texture2D Texture { get; } = texture;
    private SpriteAnimation Animation { get; } = animation;

    public virtual void Draw(SpriteBatch spriteBatch, ShapeBatch shapeBatch)
    {
        spriteBatch.Draw(
            texture: Texture,
            position: ScaledPos,
            sourceRectangle: Animation.CurrentFrame.Dim,
            color: Color.White,
            rotation: Rotation,
            origin: Origin,
            scale: Scale,
            effects: Animation.CurrentFrame.Effects,
            layerDepth: Pos.Y / 10
        );
    }

    public virtual void Update(float delta, Vector2 gameBounds)
    {
        Animation.Update(delta, gameBounds);
    }
}
