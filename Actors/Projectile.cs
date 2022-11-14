using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    public class Projectile
    {
        private int _x;
        private int _y;
        private float _vx;
        private float _vy;
        private bool _isDead;
        private float _lifeTime;
        private int _damage;
        private Texture2D _sprite;
        private Rectangle _rectangle;
        public Vector2 Position {get {return new Vector2(_x, _y); } }
        public int Damage { get => _damage; }
        public bool IsDead { get => _isDead; set { _isDead = value; }}

        public Projectile(int x, int y, float vx, float vy, Texture2D sprite, float lifeTime, int damage)
        {
            _damage = damage;
            _lifeTime = lifeTime * 1000;
            _isDead = false;
            _x = x;
            _y = y;
            _vx = vx;
            _vy = vy;
            _sprite = sprite;
            _rectangle = new Rectangle(_x, _y, 25, 25);
        }

        public void Update(GameTime gameTime)
        {
            _lifeTime -= gameTime.ElapsedGameTime.Milliseconds;
            if(_lifeTime <= 0)
                _isDead = true;
            _x += (int)(_vx*gameTime.ElapsedGameTime.Milliseconds);
            _y += (int)(_vy*gameTime.ElapsedGameTime.Milliseconds);
            _rectangle.X = _x;
            _rectangle.Y = _y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(!_isDead)
                spriteBatch.Draw(_sprite, _rectangle, Color.White);
        }
    }
}