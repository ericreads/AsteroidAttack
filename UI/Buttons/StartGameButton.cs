using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    public class StartGameButton : Button
    {
        public StartGameButton(string name, int x, int y, SpriteFont font, Color defaultColor, Color highlightColor) : base(name, x, y, font, defaultColor, highlightColor)
        {
            
        }
        public override void onClick()
        {
            GameScreenManager.getInstance().ClearScreens();
            GameScreenManager.getInstance().AddScreen(new Gameplay());
        }
    }
}