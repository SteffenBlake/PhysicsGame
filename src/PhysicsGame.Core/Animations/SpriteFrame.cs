using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsGame.Core.Animations;

public class SpriteFrame
{
    public float Length { get; set; } = 1 / 16;

    public required Rectangle Dim { get; set; }

    public SpriteEffects Effects { get; set; } = SpriteEffects.None;
}
