using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace SpaceShooter
{
    public class Enemy
    {
        private Vector2 _pos;
        private Texture2D _sprite; 
        private static float SPEED = 1;
        private int _health;
        private bool _hasDied;
        public bool HasDied { get => _hasDied; }
        private Rectangle _rectangle;
        public Vector2 Position { get => _pos; }
        
        public Enemy(int x, int y, int health, Texture2D sprite)
        {
            _hasDied = false;
            _health = health;
            _pos = new Vector2(x, y);
            _sprite = sprite;
            _rectangle = new Rectangle((int)_pos.X, (int)_pos.Y, 50, 50);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(!_hasDied)
                spriteBatch.Draw(_sprite, _rectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            _pos.Y += (int)(SPEED*gameTime.ElapsedGameTime.Milliseconds);
            _rectangle.Y = (int)_pos.Y;
            
        }
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
                _hasDied = true;
        }
    }
}