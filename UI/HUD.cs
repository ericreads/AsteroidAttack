using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceShooter
{
    public class HUD
    {
        private SpriteFont _font;
        private Player _player;

        public HUD(Player player)
        {
            _player = player;
        }
        public void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("font");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, "SCORE: $" + _player.Score, new Vector2(20, 20), Color.White);
        }
    }
}