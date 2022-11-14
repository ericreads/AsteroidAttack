using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    public abstract class Button
    {
        private string _text;
        private int _x;
        private int _y;
        private SpriteFont _font;
        private Color _color;
        private Color _defaultColor;
        private Color _highlightColor;

        public Button(string text, int x, int y, SpriteFont font, Color deafultColor, Color highlightColor)
        {
            _text = text;
            _x = x;
            _y = y;
            _font = font;
            _defaultColor = deafultColor;
            _highlightColor = highlightColor;
            _color = _defaultColor;
        }
        public void Update()
        {
            Vector2 size = _font.MeasureString(_text);
            if(Mouse.GetState().Position.X > _x && Mouse.GetState().Position.X < _x + size.X && Mouse.GetState().Position.Y > _y && Mouse.GetState().Position.Y < _y + size.Y)
            {
                _color = _highlightColor;
                if(Mouse.GetState().LeftButton == ButtonState.Pressed)
                    onClick();
            } else
                _color = _defaultColor;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _text, new Vector2(_x, _y), _color);
        }
        public abstract void onClick();
    }
}