using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
namespace SpaceShooter
{
    public class MainMenu : GameScreen
    {
        private StartGameButton _startGame;
        private SpriteFont _buttonFont;
        private SpriteFont _titleFont;
        private SpriteFont _scoreFont;
        private int _highScore;

        public override void Initialize()
        {
            if(File.Exists("HighScore.csv"))
                _highScore = Convert.ToInt32(File.ReadAllText("HighScore.csv"));
            else
                _highScore = 0;
        }
        public override void LoadContent(ContentManager content)
        {
            _buttonFont = content.Load<SpriteFont>("ButtonFont");
            _titleFont = content.Load<SpriteFont>("TitleFont");
            _scoreFont = content.Load<SpriteFont>("ScoreFont");
            _startGame = new StartGameButton("Start Game", (int)(750/2-_buttonFont.MeasureString("Start Game").X/2), 600, _buttonFont, Color.White, Color.CornflowerBlue);
        }
        public override void Update(GameTime gameTime)
        {
            _startGame.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_titleFont, "Asteroid", new Vector2(110, 50), Color.White);
            spriteBatch.DrawString(_titleFont, "Attack", new Vector2(175, 200), Color.White);
            spriteBatch.DrawString(_scoreFont, "High Score: $" + _highScore, new Vector2(135, 350), Color.White);
            _startGame.Draw(spriteBatch);
        }
    }
}