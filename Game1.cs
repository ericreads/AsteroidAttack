using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceShooter;

public class SpaceShooter : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private StarField _starField;
    private Song _song;
    public SpaceShooter()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 750;
        _graphics.PreferredBackBufferHeight = 1000;
        Content.RootDirectory = "Content";
        _starField = new StarField();
        GameScreenManager.getInstance().SetContent(Content);
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
        Window.Title = "Asteroid Attack";
        GameScreenManager.getInstance().AddScreen(new MainMenu());
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _starField.LoadContent(Content);
        _song = Content.Load<Song>("song");
        MediaPlayer.Play(_song);
        MediaPlayer.Volume = 0.5f;
        MediaPlayer.IsRepeating = true;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        GameScreenManager.getInstance().Update(gameTime);
        _starField.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp);
        _starField.Draw(_spriteBatch);
        GameScreenManager.getInstance().Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
