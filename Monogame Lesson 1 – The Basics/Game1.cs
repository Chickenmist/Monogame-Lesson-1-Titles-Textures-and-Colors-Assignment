using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Lesson_1___The_Basics
{
    enum Screen
    {
        Grid, 
        GreenHill,
        AngelIsland
    }


    public class Game1 : Game
    {
        Texture2D greenHillZoneTexture;
        Texture2D angelIslandZoneTexture;

        Texture2D sonicTexture;
        Texture2D tailsTexture;
        Texture2D eggmanTexture;
        Texture2D knucklesTexture;
        Texture2D chaosEmeraldTexture;
        Texture2D motobugTexture;

        Screen screen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Random _random = new Random();
        private int _tailsLocation;

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

            screen = (Screen)_random.Next(3);

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            Window.Title = "My First Monogame Project";


            if (screen == Screen.GreenHill)
            {
                _tailsLocation = _random.Next(0, 800 - tailsTexture.Width);
            }
            else if (screen == Screen.AngelIsland)
            {
                _tailsLocation = _random.Next(200, 800 - tailsTexture.Width);
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            greenHillZoneTexture = Content.Load<Texture2D>("greenHillZoneBackground");
            angelIslandZoneTexture = Content.Load<Texture2D>("angelIslandZone");

            sonicTexture = Content.Load<Texture2D>("sonicSprite");
            tailsTexture = Content.Load<Texture2D>("tailsSprite");
            eggmanTexture = Content.Load<Texture2D>("eggmanSprite");
            knucklesTexture = Content.Load<Texture2D>("knucklesSprite");
            chaosEmeraldTexture = Content.Load<Texture2D>("chaosEmeraldSprite");
            motobugTexture = Content.Load<Texture2D>("motobugSprite");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();



            if (screen == Screen.GreenHill)
            {
                _spriteBatch.Draw(greenHillZoneTexture, new Vector2(0, 0), Color.White);
                
                _spriteBatch.Draw(eggmanTexture, new Vector2(-50,230), Color.White);
                _spriteBatch.Draw(sonicTexture, new Vector2(450,250), Color.White);
                _spriteBatch.Draw(knucklesTexture, new Vector2(700, 240), Color.White);
                _spriteBatch.Draw(chaosEmeraldTexture, new Vector2(550, 250), Color.White);
                _spriteBatch.Draw(tailsTexture, new Vector2(_tailsLocation, 10), Color.White);

                for (int i = 120; i < 300; i += 100)
                {
                    _spriteBatch.Draw(motobugTexture, new Vector2(i, 290), Color.White);
                }
            }
            else if (screen == Screen.AngelIsland)
            {
                _spriteBatch.Draw(angelIslandZoneTexture,new Vector2(0,0), Color.White);

                _spriteBatch.Draw(tailsTexture, new Vector2(_tailsLocation, 10), Color.White);
                _spriteBatch.Draw(eggmanTexture, new Vector2(-50, 170), Color.White);
                _spriteBatch.Draw(sonicTexture, new Vector2(400, 240), Color.White);
                _spriteBatch.Draw(knucklesTexture, new Vector2(650, 230), Color.White);
                _spriteBatch.Draw(chaosEmeraldTexture, new Vector2(500, 240), Color.White);

                for (int i = 120; i < 300; i += 100)
                {
                    _spriteBatch.Draw(motobugTexture, new Vector2(i, 285), Color.White);
                }
            }
            else if (screen == Screen.Grid)
            {
                for (int i = 0; i < 800 - sonicTexture.Width; i += sonicTexture.Width)
                {
                    for (int j = 0; j < 500 - sonicTexture.Height; j += sonicTexture.Height)
                    {
                        _spriteBatch.Draw(sonicTexture, new Vector2(i, j), Color.White);
                    }
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}