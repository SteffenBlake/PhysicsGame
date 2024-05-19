using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PhysicsGame.Core.Abstractions;

namespace PhysicsGame.Core.Animations;

public class SpriteAnimation : IProgressable
{
    public float Time { get; set; } = 0.0f;

    public required SpriteFrame[] Frames { get; set; }

    public SpriteFrame CurrentFrame => Frames[_currentFrame];

    public required bool Repeats { get; set; }

    private int _currentFrame = 0;
    public void Update(float delta, Vector2 gameBounds)
    {
        Time += delta;
        while (Frames[_currentFrame].Length < Time)
        {
            Time -= Frames[_currentFrame].Length;
            _currentFrame++;
            if (_currentFrame == Frames.Length)
            {
                _currentFrame = 0;
            }
        }
    }

    public static SpriteAnimation From(
        int frameWidth,
        int frameHeight,
        int rowStart = 0,
        int colStart = 0,
        int frameCount = 1,
        float fps = 16,
        float startTimeSeconds = 0.0f,
        SpriteEffects effects = SpriteEffects.None,
        bool repeats = false
    )
    {
        var frames = new SpriteFrame[frameCount];
        var top = rowStart * frameHeight;
        var frameLength = 1 / fps;
        for (var f = 0; f < frameCount; f++)
        {
            var left = (f + colStart) * frameWidth;
            frames[f] = new()
            {
                Length = frameLength,
                Dim = new Rectangle(left, top, frameWidth, frameHeight),
                Effects = effects
            };
        }
        return new SpriteAnimation()
        {
            Frames = frames,
            Time = startTimeSeconds,
            Repeats = repeats
        };
    }
}
