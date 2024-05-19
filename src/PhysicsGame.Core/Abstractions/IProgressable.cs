using Microsoft.Xna.Framework;

namespace PhysicsGame.Core.Abstractions;

public interface IProgressable
{
    public void Update(float delta, Vector2 gameBounds);
}
