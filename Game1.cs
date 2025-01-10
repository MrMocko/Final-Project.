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

        Texture2D strtButtonTexture;
        Rectangle strtButtonRect;

        Texture2D ballTexture;
        Rectangle ballRect;
        Vector2 ballSpeed;

        SpriteFont fadeFont;

        Rectangle p2BarLocation;
        Rectangle p1BarLocation;

        KeyboardState keyboardState;








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

            P1BarRect = new Rectangle(740, 340, 10, 120);
            P2BarRect = new Rectangle(50, 150, 10, 120);
            strtButtonRect = new Rectangle(240, 320, 320, 120);
            ballRect = new Rectangle(240, 320, 30, 30);
            p2BarLocation = new Rectangle(50, 150, 10, 120);
            p1BarLocation = new Rectangle(740, 340, 10, 120);

            ballSpeed = new Vector2(4, 8);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            P1BarTexture = Content.Load<Texture2D>("P1 Bar");
            P2BarTexture = Content.Load<Texture2D>("P2 Bar");
            introBackround = Content.Load<Texture2D>("intro Backround (2)");
            midBackround = Content.Load<Texture2D>("mid Background");
            outroBackround = Content.Load<Texture2D>("outro Backround");
            strtButtonTexture = Content.Load<Texture2D>("strt Button");
            fadeFont = Content.Load<SpriteFont>("fade Font");
            ballTexture = Content.Load<Texture2D>("ball");
            outroBackround = Content.Load<Texture2D>("outro Backround");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prevMousestate = mouseState;
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            // INTRO
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMousestate.LeftButton == ButtonState.Released)
                {

                    if (strtButtonRect.Contains(mouseState.Position))
                    {
                        screen = Screen.mid;

                    }

                }



            }

            // MID
            else if (screen == Screen.mid)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    p2BarLocation.Y -= 5;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    p2BarLocation.Y += 5;
                }
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    p1BarLocation.Y -= 5;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    p1BarLocation.Y += 5;
                }
                ballRect.X += (int)ballSpeed.X;
                ballRect.Y += (int)ballSpeed.Y;
                if (ballRect.Right > window.Width || ballRect.Left < 0)
                    ballSpeed.X *= -1;
                if (ballRect.Bottom > window.Height || ballRect.Top < 0)
                    ballSpeed.Y *= -1;
                if (ballRect.Intersects(P1BarRect))
                {
                    ballRect.X = P1BarRect.Left - ballRect.Width;
                    ballRect.X = P1BarRect.Right;
                    if (ballRect.Intersects(P1BarRect))
                    {
                        ballRect.Y = P1BarRect.Top - ballRect.Height;
                    }
                    ballRect.Y = P1BarRect.Bottom;
                }
            }

            // OUTRO
            else if (screen == Screen.Outro)
            {

            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            //INTRO SCREEN
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introBackround, new Vector2(0, 0), Color.White);
                _spriteBatch.Draw(strtButtonTexture, strtButtonRect, Color.White);
                _spriteBatch.DrawString(fadeFont, "PONG", new Vector2(230, 190), Color.Red);
            }
            //MID SCREEN
            if (screen == Screen.mid)
            {
                _spriteBatch.Draw(midBackround, new Vector2 (0,0), Color.White); 
                _spriteBatch.Draw(P1BarTexture, p1BarLocation, Color.White);
                _spriteBatch.Draw(P2BarTexture, p2BarLocation, Color.White);
                _spriteBatch.Draw(ballTexture, ballRect, Color.White);
            }




                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
