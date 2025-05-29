using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheEyeThatFollows
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _GameFont;
        private Texture2D _Rectangle;

        private Eye _PoohbahTheGrand; //Theres a lot in a name.


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

            // TODO: use this.Content to load your game content here
            _Rectangle = Content.Load<Texture2D>("MonogameWindow"); //Will be used for tracking the mouse eventually.
            _GameFont = Content.Load<SpriteFont>("GameFont"); //Yay! The font!

            //Load up Poobah!
            _PoohbahTheGrand = new Eye("Poohbah The Grand", Content.Load<Texture2D>("Iris"), Content.Load<Texture2D>("EyeLid"), Content.Load<Texture2D>("EyeBase"), Content.Load<SpriteFont>("GameFont"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _PoohbahTheGrand.Update(); //Update that eye!
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.Begin();
            _PoohbahTheGrand.Draw(_spriteBatch); //Draw Poobah!
            _spriteBatch.Draw(_Rectangle,new Vector2(400, 240), Color.White);
            _spriteBatch.End();
        }
    }
}
