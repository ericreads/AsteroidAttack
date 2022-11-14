using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    public abstract class GameScreen
    {
        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}