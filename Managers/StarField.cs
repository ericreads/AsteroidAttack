using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
namespace SpaceShooter
{
    public class StarField
    {
        private List<Star> _stars;
        private Texture2D _sprite;
        private Random _randGen;

        public StarField()
        {
            _stars = new List<Star>();
            _randGen = new Random();
        }

        public void LoadContent(ContentManager content)
        {
            _sprite = content.Load<Texture2D>("star");
        }

        public void Update(GameTime gameTime)
        {
            if(_randGen.Next(0, 10) < 5)
                _stars.Add(new Star(_randGen.Next(0, 750), -10, _randGen.Next(2, 7), _sprite));
            foreach(Star s in _stars)
            {
                s.Update(gameTime);
            }
            for(int i = 0; i < _stars.Count; i++)
            {
                if(_stars[i].IsDead)
                {
                    _stars.Remove(_stars[i]);
                    i--;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Star s in _stars)
            {
                s.Draw(spriteBatch);
            }
        }
    }
}