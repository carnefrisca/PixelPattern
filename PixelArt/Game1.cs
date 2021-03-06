﻿namespace PixelArt
{
    using BmFont;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D square;
        private Texture2D background;
        FontRenderer _fontRenderer;
        Rectangle rect;
        string windowTitle = "Pixel Pattern";
        string PatternType = "";

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Window.Title = windowTitle + "-" + PatternType;
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
            PatternType = "HORIZONTAL";
            square = new Texture2D(GraphicsDevice, 1, 2);
            square.CreatePattern(Patterns.HORIZONTAL, new Color[] { Color.Transparent, Color.Black });

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            var fontFilePath = Path.Combine(Content.RootDirectory, "myfonts.fnt");
            var fontFile = FontLoader.Load(fontFilePath);
            var fontTexture = Content.Load<Texture2D>("myfonts_0.png");

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("stage");
            _fontRenderer = new FontRenderer(fontFile, fontTexture);

            graphics.PreferredBackBufferWidth = background.Width;
            graphics.PreferredBackBufferHeight = background.Height;
            graphics.ApplyChanges();

            rect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
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
            KeyboardState state = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            UpdatePatternByInput();

            Window.Title = windowTitle + "-" + PatternType;

            base.Update(gameTime);
        }

        private void UpdatePatternByInput()
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.D1) || newState.IsKeyDown(Keys.NumPad1))
            {
                PatternType = "HORIZONTAL";
                square = new Texture2D(GraphicsDevice, 1, 2);
                square.CreatePattern(Patterns.HORIZONTAL, new Color[] { Color.Transparent, Color.Black });
            }
            if (newState.IsKeyDown(Keys.D2) || newState.IsKeyDown(Keys.NumPad2))
            {
                PatternType = "VERTICAL";
                square = new Texture2D(GraphicsDevice, 2, 1);
                square.CreatePattern(Patterns.VERTICAL, new Color[] { Color.Transparent, Color.Black });
            }
            if (newState.IsKeyDown(Keys.D3) || newState.IsKeyDown(Keys.NumPad3))
            {
                PatternType = "DIAGONAL3x3";
                square = new Texture2D(GraphicsDevice, 3, 3);
                square.CreatePattern(Patterns.DIAGONAL3x3, new Color[] { Color.Transparent, Color.Black });
            }
            if (newState.IsKeyDown(Keys.D4) || newState.IsKeyDown(Keys.NumPad4))
            {
                PatternType = "DIAGONAL_4x4";
                square = new Texture2D(GraphicsDevice, 4, 4);
                square.CreatePattern(Patterns.DIAGONAL_4x4, new Color[] { Color.Transparent, Color.Black });
            }
            if (newState.IsKeyDown(Keys.D5) || newState.IsKeyDown(Keys.NumPad5)) {
                PatternType = "DIAG_LIGHT_LEFT_4x4";
                square = new Texture2D(GraphicsDevice, 4, 4);
                square.CreatePattern(Patterns.DIAG_LIGHT_LEFT_4x4, new Color[] {
                    Color.Transparent,
                    PatternManager.ToColor("121212"),
                    PatternManager.ToColor("3e3e3e"),
                    PatternManager.ToColor("696969"),
                    PatternManager.ToColor("c0c0c0"),
                    PatternManager.ToColor("e0e0e0"),
                    PatternManager.ToColor("efefef"),
                });
            }
            if (newState.IsKeyDown(Keys.D6) || newState.IsKeyDown(Keys.NumPad6)) {
                PatternType = "LIGHT_TOP_4x4";
                square = new Texture2D(GraphicsDevice, 4, 4);
                square.CreatePattern(Patterns.LIGHT_TOP_4x4, new Color[] { 
                Color.Transparent,
                PatternManager.ToColor("FFdfdfdf"),
                PatternManager.ToColor("FFc9c9c9"),
                PatternManager.ToColor("FF9f9f9f"),
                PatternManager.ToColor("FFffffff"),
                PatternManager.ToColor("FFeaeaea"), 
                PatternManager.ToColor("FFbebebe"),
                PatternManager.ToColor("FF6a6a6a")
                });
            }
            if (newState.IsKeyDown(Keys.D7) || newState.IsKeyDown(Keys.NumPad7)) {
                PatternType = "LIGHT_4x4";
                square = new Texture2D(GraphicsDevice, 4, 4);
                square.CreatePattern(Patterns.LIGHT_4x4, new Color[] {
                    Color.Transparent,
                    PatternManager.ToColor("FF7f7f7f"),
                    PatternManager.ToColor("FF404040"),
                    PatternManager.ToColor("FFbfbfbf")
                });
            }
        }

        public static FontFile Load(Stream stream)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(FontFile));
            FontFile file = (FontFile)deserializer.Deserialize(stream);
            return file;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.Draw(background, rect, Color.White);

            for (int x = 0; x < graphics.PreferredBackBufferWidth; x++)
            {
                for (int y = 0; y < graphics.PreferredBackBufferHeight; y++)
                {
                    spriteBatch.Draw(square, new Rectangle(x * 5, y * 5, 5, 5), Color.White);
                }
            }
            _fontRenderer.DrawText(spriteBatch, 0, 0, "To change the pattern:");
            _fontRenderer.DrawText(spriteBatch, 0, 30, "Press the key from 1 to 7");
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    public class FontRenderer
    {
        public FontRenderer(FontFile fontFile, Texture2D fontTexture)
        {
            _fontFile = fontFile;
            _texture = fontTexture;
            _characterMap = new Dictionary<char, FontChar>();

            foreach (var fontCharacter in _fontFile.Chars)
            {
                char c = (char)fontCharacter.ID;
                _characterMap.Add(c, fontCharacter);
            }
        }

        private Dictionary<char, FontChar> _characterMap;
        private FontFile _fontFile;
        private Texture2D _texture;
        public void DrawText(SpriteBatch spriteBatch, int x, int y, string text)
        {
            int dx = x;
            int dy = y;
            foreach (char c in text)
            {
                FontChar fc;
                if (_characterMap.TryGetValue(c, out fc))
                {
                    var sourceRectangle = new Rectangle(fc.X, fc.Y, fc.Width, fc.Height);
                    var position = new Vector2(dx + fc.XOffset, dy + fc.YOffset);

                    spriteBatch.Draw(_texture, position, sourceRectangle, Color.Red);
                    dx += fc.XAdvance;
                }
            }
        }
    }
}
