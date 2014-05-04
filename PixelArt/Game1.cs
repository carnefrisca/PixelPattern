#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PixelArt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D square;
        private Texture2D background;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            square = new Texture2D(GraphicsDevice, 4, 4);
            square.CreatePattern(Patterns.DIAGONAL_4x4, new Color[] { Color.Transparent, Color.Linen });
            //square.CreatePattern(Patterns.DIAG_LIGHT_LEFT_4x4, new Color[] { 
            //    PatternManager.ToColor("121212"),
            //    PatternManager.ToColor("3e3e3e"),
            //    PatternManager.ToColor("696969"),
            //    PatternManager.ToColor("c0c0c0"),
            //    PatternManager.ToColor("e0e0e0"),
            //    PatternManager.ToColor("efefef"),
            //    Color.Transparent });
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("stage");

            graphics.PreferredBackBufferWidth = background.Width;
            graphics.PreferredBackBufferHeight = background.Height;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            for (int x = 0; x < graphics.PreferredBackBufferWidth; x++)
            {
                for (int y = 0; y < graphics.PreferredBackBufferHeight; y++)
                {
                    spriteBatch.Draw(square, new Rectangle(x * 5, y * 5, 5, 5), Color.White);
                }
            }
           
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
