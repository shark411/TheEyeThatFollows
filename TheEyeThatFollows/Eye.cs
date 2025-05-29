using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheEyeThatFollows
{
    internal class Eye
    {
        private Random _rng; //To generate random numbers
        private Texture2D _iris; //Our texture
        private Texture2D _eyelid; //The eyelid
        private Texture2D _eyebase; //The base of the eye
        private Color _eyeColour; //To make the eye change colours
        private string _eyeName; //The name of the eye
        private SpriteFont _GameFont; //Our font
        private bool _isBlinking; //To check if it's blinking
        private float _blinkTimer; //So it isnt always blinking

        //Constructor
        public Eye(String eyeName, Texture2D iris, Texture2D eyelid, Texture2D eyebase, SpriteFont GameFont)
        {
            _rng = new Random();
            _eyeName = eyeName;
            _GameFont = GameFont;
            _eyeColour = new Color(128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129));
            _iris = iris;
            _eyelid = eyelid;
            _eyebase = eyebase;
            _isBlinking = false;
            _blinkTimer = 60;
        }

        public Rectangle GetBounds() //Eye Hitbox
        {
            return new Rectangle(350, 180, 100, 100);
        }
        public bool IsBlinking() //To check if the eye is blinking
        {
            return _isBlinking;
        }
        public void Update()
        {
            _blinkTimer--;
            if (_blinkTimer <= 0) //Dont always blink!!!
            {
                _isBlinking = false;
            }

            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (GetBounds().Contains(currentMouseState.Position)) //If you touch the eye, it blinks!
                {
                    _isBlinking = true;
                    _blinkTimer = 60;
                }
                //No else because that makes it stop blinking when you click away!
                //The eye should feel pain.
            }
            }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_eyebase, new Vector2(350, 180), Color.White); //EYEWHITE FIRST
            spriteBatch.Draw(_iris, new Vector2(350, 180), _eyeColour); //IRIS SECOND
            if (_isBlinking == true) //If it's blinking, lets actually blink!
            {
                spriteBatch.Draw(_eyelid, new Vector2(350, 180), Color.White);
                spriteBatch.DrawString(_GameFont, "Ow! How dare you touch " + _eyeName + "'s eye!", new Vector2(210, 150), Color.Red);
            }
            else //Wide eyed and beautiful
            {
                spriteBatch.Draw(_eyelid, new Vector2(350, 180), Color.White * 0);
                spriteBatch.DrawString(_GameFont, "Ow!", new Vector2(350, 150), Color.Red * 0);
            }
        }
    }
}
