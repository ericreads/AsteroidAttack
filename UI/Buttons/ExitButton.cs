using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    public class ExitButton : Button
    {
        public ExitButton(string name, int x, int y, SpriteFont font, Color defaultColor, Color hoverColor) : base(name, x, y, font, defaultColor, hoverColor)
        {

        }
        public override void onClick()
        {
            SpaceShooter.ShouldExit();
        }
    }
}