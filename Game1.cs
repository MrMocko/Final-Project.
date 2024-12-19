using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Project_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        enum Screen
        {
            Intro,
            mid,
            Outro,
        }

        Screen screen;

        Texture2D introBackround;
        Texture2D midBackround;
        Texture2D outroBackround;

        Rectangle window;

        Texture2D P1BarTexture;
        Rectangle P1BarRect;

        Texture2D P2BarTexture;
        Rectangle P2BarRect;

        MouseState prevMousestate;
        MouseState mouseState;

        Texture2D startButtonTexture;
        Rectangle startButtonRect;










        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            P1BarRect = new Rectangle(780, 390, 10, 120);
            P2BarRect = new Rectangle(10, 90, 10, 120);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            P1BarTexture = Content.Load<Texture2D>("P1 Bar");
            P2BarTexture = Content.Load<Texture2D>("P2 Bar");
            introBackround = Content.Load<Texture2D>("intro Backround (2)");
            midBackround = Content.Load<Texture2D>("mid Background");
            //outroBackround = Content.Load<Texture2D>("outro Backround");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //INTRO SCREEN

            if (screen == Screen.Intro)
            {
                 if (mouseState.LeftButton == ButtonState.Pressed && prevMousestate.LeftButton == ButtonState.Released) 
                 {
                    screen = Screen.mid;
                 }
            }

            //MID SCREEN 
            if (screen == Screen.mid)
            {
                if (screen == Screen.mid) 
                {
                    screen = Screen.Outro;
                }
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(P1BarTexture, P1BarRect, Color.White);
            _spriteBatch.Draw(P2BarTexture, P2BarRect, Color.White);
            //INTRO SCREEN
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introBackround, new Vector2(0, 0), Color.White);
            }
            //MID SCREEN
            if (screen == Screen.mid)
            {
                _spriteBatch.Draw(midBackround, new Vector2 (0,0), Color.White);
            }




                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
