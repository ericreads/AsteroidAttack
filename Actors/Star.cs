using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    public class Star
    {
        private int _x;
        private int _y;
        private int _distance;
        private static float SPEED = 0.5f;
        private static float SIZE = 3;
        private bool _isDead;
        public bool IsDead { get => _isDead; }
        private Texture2D _sprite;
        private Rectangle _rectangle;
        public Star(int x, int y, int dist, Texture2D sprite)
        {
            _isDead = false;
            _sprite = sprite;
            _x = x;
            _y = y;
            _distance = dist;
            _rectangle = new Rectangle(_x, _y, (int)(SIZE/_distance+1), (int)(SIZE/_distance+1));
        }
        public void Update(GameTime gameTime)
        {
            _y += (int)(SPEED*_distance*gameTime.ElapsedGameTime.Milliseconds);
            if(_y >= 1000)
                _isDead = true;
            _rectangle.Y = _y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite, _rectangle, Color.White);
        }
    }
}