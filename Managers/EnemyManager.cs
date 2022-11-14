using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
namespace SpaceShooter
{
    public class EnemyManager
    {
        private Random _randGen;
        private Player _player;
        private ProjectileManager _projectileManager;
        private List<Enemy> _enemies;
        private Texture2D _sprite;

        public EnemyManager(Player player, ProjectileManager projectileManager)
        {
            _randGen = new Random();
            _player = player;
            _projectileManager = projectileManager;
            _enemies = new List<Enemy>();
        }

        public void LoadContent(ContentManager content)
        {
            _sprite = content.Load<Texture2D>("Asteroid");
        }

        public void Update(GameTime gameTime)
        {
            if(_randGen.Next(0, 100) < 5)
                _enemies.Add(new Enemy(_randGen.Next(0, 700), -50, 2, _sprite));
            foreach(Projectile p in _projectileManager.Projectiles)
            {
                foreach(Enemy e in _enemies)
                {
                    if(e.Position.X < p.Position.X + 25 && p.Position.X < e.Position.X+50 && e.Position.Y < p.Position.Y + 25 && p.Position.Y < e.Position.Y + 50)
                    {
                        e.TakeDamage(p.Damage);
                        p.IsDead = true;
                    }
                }
            }
            for(int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].Update(gameTime);
                if(_enemies[i].Position.X < _player.Position.X + 50 && _player.Position.X < _enemies[i].Position.X+50 && _enemies[i].Position.Y < _player.Position.Y + 50 && _player.Position.Y < _enemies[i].Position.Y + 50)
                {
                       _player.Kill();
                }
                if(_enemies[i].HasDied)
                {
                    _player.AddToScore(100);
                    _enemies.Remove(_enemies[i]);
                    i--;
                }
            }
            for(int i = 0; i < _enemies.Count; i++)
            {
                if(_enemies[i].Position.Y >= 1000)
                {
                    _enemies.Remove(_enemies[i]);
                    i--;
                }

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Enemy e in _enemies)
            {
                e.Draw(spriteBatch);
            }
        }

    }
}