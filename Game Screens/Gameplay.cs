using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    public class Gameplay : GameScreen
    {
        private Player _player;
        private ProjectileManager _projectileManager;
        private EnemyManager _enemyManager;
        private HUD _hud;
        public override void Initialize()
        {
            _projectileManager = new ProjectileManager("projectile");
            _player = new Player(750/2, 900, _projectileManager);
            _enemyManager = new EnemyManager(_player, _projectileManager);
            _hud = new HUD(_player);
        }
        public override void LoadContent(ContentManager content)
        {
            _projectileManager.LoadContent(content);
            _player.LoadContent(content);
            _enemyManager.LoadContent(content);
            _hud.LoadContent(content);
        }
        public override void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            _projectileManager.Update(gameTime);
            _enemyManager.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
            _projectileManager.Draw(spriteBatch);
            _enemyManager.Draw(spriteBatch);
            _hud.Draw(spriteBatch);
        }
    }
}