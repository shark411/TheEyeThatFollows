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
        }
    }
}
