﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheEyeThatFollows
{
    public class Game1 : Game
    {   //Greetings you who reads this. This program is meant to have an eye that follows mouse clicks,
        //blinks when clicked and changes eye colour when the space is pressed.
        //No AI was used to make this monstrocity.
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _GameFont;

        private Eye _PoohbahTheGrand; //There's a lot in a name.


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _GameFont = Content.Load<SpriteFont>("GameFont"); //Yay! The font!

            //Load up Poobah!
            _PoohbahTheGrand = new Eye("Poohbah The Grand", Content.Load<Texture2D>("Iris"), Content.Load<Texture2D>("EyeLid"), Content.Load<Texture2D>("EyeBase"), Content.Load<SpriteFont>("GameFont"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _PoohbahTheGrand.Update(); //Update that eye!
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            base.Draw(gameTime);
            _spriteBatch.Begin();
            _PoohbahTheGrand.Draw(_spriteBatch); //Draw Poobah!

            //Maybe we'll add some intructions
            _spriteBatch.DrawString(_GameFont, "The eye can only see MOUSE CLICKS...", new Vector2(5, 440), Color.White);
            _spriteBatch.DrawString(_GameFont, "Press SPACE to change the eye colour.", new Vector2(5, 460), Color.White);
            _spriteBatch.End();
        }
    }
}
