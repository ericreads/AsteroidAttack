using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace SpaceShooter
{
    public class ProjectileManager
    {
        private List<Projectile> _projectiles;
        private Texture2D _sprite;
        private string _spritePath;
        public List<Projectile> Projectiles { get => _projectiles; }
        public ProjectileManager(string spritePath)
        {
            _spritePath = spritePath;
            _projectiles = new List<Projectile>();
        }
        public void LoadContent(ContentManager content)
        {
            _sprite = content.Load<Texture2D>(_spritePath);
        }
        public void Add(int x, int y, int vx, int vy, int lifeTime, int damage)
        {
            _projectiles.Add(new Projectile(x, y, vx, vy, _sprite, lifeTime, damage));
        }
        public void Update(GameTime gameTime)
        {
            for(int i = 0; i < _projectiles.Count; i++)
            {
                _projectiles[i].Update(gameTime);
                if(_projectiles[i].IsDead)
                {
                    _projectiles.Remove(_projectiles[i]);
                    i--;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Projectile p in _projectiles)
            {
                p.Draw(spriteBatch);
            }
        }
    }
}