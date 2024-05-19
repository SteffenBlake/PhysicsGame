using Microsoft.Xna.Framework;

namespace PhysicsGame.Core;

public class Entity(float gameScale)
{
    public Vector2 Pos { get; set; } = new();

    public Vector2 ScaledPos => Pos * GameScale;

    public float Rotation { get; set; } = 0.0f;

    protected float GameScale { get; } = gameScale;
}
