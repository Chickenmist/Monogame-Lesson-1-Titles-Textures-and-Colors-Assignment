using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Lesson_1___The_Basics
{
    public class Game1 : Game
    {
        Texture2D greenHillZoneTexture;
        Texture2D angelIslandZoneTexture;

        Texture2D sonicTexture;
        Texture2D tailsTexture;
        Texture2D eggmanTexture;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Random _random = new Random();
        private int _background;

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

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            this.Window.Title = "My First Monogame Project";

            _background = _random.Next(1,3);
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

            if (_background == 1) //Green Hill Zone screen
            {
                _spriteBatch.Draw(greenHillZoneTexture, new Vector2(0, 0), Color.White);
                
                _spriteBatch.Draw(eggmanTexture, new Vector2(-50,230), Color.White);
                _spriteBatch.Draw(sonicTexture, new Vector2(400,250), Color.White);
            }
            else if (_background == 2) //Angel Island Zone screen
            {
                _spriteBatch.Draw(angelIslandZoneTexture,new Vector2(0,0), Color.White);
            }

            
            _spriteBatch.Draw(tailsTexture, new Vector2(100,30), Color.White);
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}