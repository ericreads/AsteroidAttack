using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.IO;

namespace SpaceShooter
{
    public class Player
    {
        private int _x;
        private int _y;
        private static int WIDTH = 50;
        private static int HEIGHT = 50;
        private static float SPEED = 0.5f;
        private int _shootTimer;
        private int _score;
        private bool _isDead;
        private ProjectileManager _projectileManager;
        private Texture2D _sprite;
        private Rectangle _rectangle;
        private SoundEffect _shootSoundEffect;
        private SoundEffect _deathSoundEffect;
        public int Score { get => _score; }
        public Vector2 Position {get {return new Vector2(_x, _y);}}

        public Player(int x, int y, ProjectileManager projectileManager)
        {
            _score = 0;
            _shootTimer = 0;
            _projectileManager = projectileManager;
            _x = x;
            _y = y;
            _rectangle = new Rectangle(_x, _y, WIDTH, HEIGHT);
        }
        public void AddToScore(int a)
        {
            _score += a;
        }
        public void LoadContent(ContentManager content)
        {
            _sprite = content.Load<Texture2D>("player");
            _shootSoundEffect = content.Load<SoundEffect>("shoot");
            _deathSoundEffect = content.Load<SoundEffect>("explode");
        }

        public void Update(GameTime gameTime)
        {
            if(!_isDead)
            {
                _score += (gameTime.ElapsedGameTime.Milliseconds)/10;
                int deltaTime = gameTime.ElapsedGameTime.Milliseconds;
                if(Keyboard.GetState().IsKeyDown(Keys.Left))
                    _x -= (int)(SPEED*deltaTime);
                else if(Keyboard.GetState().IsKeyDown(Keys.Right))
                    _x += (int)(SPEED*deltaTime);
                if(Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    if(_shootTimer >= 200 || _shootTimer == 0)
                    {
                        _shootSoundEffect.Play(0.5f, 1.0f, 0.0f);
                        _projectileManager.Add(_x+10, _y, 0, -2, 2, 1);
                        _shootTimer = 0;
                    }
                    _shootTimer += gameTime.ElapsedGameTime.Milliseconds;
                } else
                {
                    _shootTimer = 0;
                }
                if(_x < 0)
                    _x = 0;
                if(_x > 700)
                    _x= 700;
                _rectangle.X = _x;
                _rectangle.Y = _y;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!_isDead)
                spriteBatch.Draw(_sprite, _rectangle, Color.White);
        }

        public void Kill()
        {
            _deathSoundEffect.Play();
            _isDead = true;
            if(File.Exists("HighScore.csv"))
            {
                if(_score > Convert.ToInt32(File.ReadAllText("HighScore.csv")))
                 File.WriteAllText("HighScore.csv", Convert.ToString(_score));
            }else
                File.WriteAllText("HighScore.csv", Convert.ToString(_score));
            GameScreenManager.getInstance().ClearScreen();
            GameScreenManager.getInstance().AddScreen(new MainMenu());
        }

    }
}