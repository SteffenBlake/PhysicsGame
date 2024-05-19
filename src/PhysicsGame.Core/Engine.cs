using System;
using Apos.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PhysicsGame.Core.Abstractions;
using PhysicsGame.Core.Entities;

namespace PhysicsGame.Core;

public class Engine : Game
{
    private const float METERS_WIDE = 10.0f;
    private float GameScale { get; set; }
    private Vector2 GameBoundsMeters { get; set; }
    private GraphicsDeviceManager? Graphics { get; set; }

    public Engine()
    {
        Console.WriteLine("Constructing Engine...");
        IsMouseVisible = false;
        Graphics = new(this)
        {
            IsFullScreen = true,
            SupportedOrientations = DisplayOrientation.LandscapeLeft,
            SynchronizeWithVerticalRetrace = false,
            GraphicsProfile = GraphicsProfile.HiDef
        };
        IsFixedTimeStep = false;
        Console.WriteLine("Engine Constructed!");
    }

    protected override void Initialize()
    {
        Console.WriteLine("Initializing Engine...");

        Graphics!.PreferredBackBufferWidth = GraphicsDevice.Viewport.Width;
        Graphics!.PreferredBackBufferHeight = GraphicsDevice.Viewport.Height;

        Console.WriteLine("Viewport Width: " + GraphicsDevice.Viewport.Width);
        Console.WriteLine("Viewport Height: " + GraphicsDevice.Viewport.Height);
        Console.WriteLine("Desired Width: " + METERS_WIDE);
        GameScale = GraphicsDevice.Viewport.Width / METERS_WIDE;
        Console.WriteLine("GameScale: " + GameScale);

        GameBoundsMeters = new(
            x: METERS_WIDE,
            y: GraphicsDevice.Viewport.Height / GameScale
        );
        Console.WriteLine($"GameBounds X:{GameBoundsMeters.X} Y:{GameBoundsMeters.Y}");

        base.Initialize();
        Console.WriteLine("Engine Initialized!");
    }

    private SpriteBatch? _spriteBatch;
    private ShapeBatch? _shapeBatch;
    private IRenderable[] _renderables = [];
    private IProgressable[] _progressables = [];

    protected override void LoadContent()
    {
        Console.WriteLine("Loading Engine Content...");
        Content.RootDirectory = "Content";

        _spriteBatch = new(GraphicsDevice);
        _shapeBatch = new(GraphicsDevice, Content);
        var font = Content.Load<SpriteFont>("Fonts/Candara");

        var fpsTxt = new FpsText(GameScale, font);
        var floor = new Floor(GameScale);

        _renderables = [fpsTxt, floor];
        _progressables = [fpsTxt];

        base.LoadContent();
        Console.WriteLine("Engine Content Loaded!");
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
        {
            Exit();
        }

        var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        for (var p = 0; p < _progressables.Length; p++)
        {
            _progressables[p].Update(delta, GameBoundsMeters);
        }

        base.Update(gameTime);
    }

    private Matrix _transformMatrix = Matrix.CreateScale(new Vector3(1.0f, 1.0f, 1.0f));
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch!.Begin(
            sortMode: SpriteSortMode.FrontToBack,
            blendState: null,
            samplerState: null,
            depthStencilState: null,
            rasterizerState: null,
            effect: null,
            transformMatrix: _transformMatrix
        );
        _shapeBatch!.Begin();

        for (var r = 0; r < _renderables.Length; r++)
        {
            _renderables[r].Draw(_spriteBatch, _shapeBatch);
        }

        _spriteBatch!.End();
        _shapeBatch!.End();
        base.Draw(gameTime);
    }
}
