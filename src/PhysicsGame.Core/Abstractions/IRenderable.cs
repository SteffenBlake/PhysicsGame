using Apos.Shapes;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsGame.Core.Abstractions;

public interface IRenderable
{
    void Draw(SpriteBatch spriteBatch, ShapeBatch shapeBatch);
}
