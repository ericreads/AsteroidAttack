using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
namespace SpaceShooter
{
    public class GameScreenManager
    {
        private Stack<GameScreen> _screens;
        private static GameScreenManager _instance;
        private ContentManager _content;
        
        public GameScreenManager()
        {
            _screens = new Stack<GameScreen>();
        }

        public static GameScreenManager getInstance()
        {
            if(_instance == null)
            {
                _instance = new GameScreenManager();
            }
            return _instance;
            
        }
        public void SetContent(ContentManager content)
        {
            _content = content;
        }
        public void AddScreen(GameScreen screen)
        {
            _screens.Push(screen);
            _screens.Peek().Initialize();
            if(_content != null)
                _screens.Peek().LoadContent(_content);
        }
        public void ClearScreen()
        {
            if(_screens.Count > 1)
            {
                _screens.Pop();
            }
        }
        public void ClearScreens()
        {
            if(_screens.Count > 0)
            {
                _screens.Clear();
            }
        }
        public void Update(GameTime gameTime)
        {
            _screens.Peek().Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _screens.Peek().Draw(spriteBatch);
        }
    }
}