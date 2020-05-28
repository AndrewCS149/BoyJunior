﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace gameTutorial
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Texture2D playerSprite;
        Texture2D mapSprite;
        Player player = new Player();
        World world = new World();
        private TiledMap map;
        private TiledMapRenderer mapRenderer;

        int mapWidth;
        int mapHeight;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            // set world size to fit monitor size
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height - 100;

            mapWidth = graphics.PreferredBackBufferWidth;
            mapHeight = graphics.PreferredBackBufferHeight;

            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            world.initialize();
            player.initialize();

            // TODO: fix this. 
            // import tmx map
            map = Content.Load<TiledMap>("maps/terrain");
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //// TODO: use this.Content to load your game content here
            playerSprite = Content.Load<Texture2D>("Imgs/blue-shirt-guy");
            mapSprite = Content.Load<Texture2D>("maps/map32x32");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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

            player.updatePosition(gameTime, playerSprite);
            player.setBoundaries(playerSprite, mapWidth, mapHeight);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            world.drawWorld(spriteBatch, mapSprite);
            player.drawPlayer(spriteBatch, playerSprite);

            base.Draw(gameTime);
        }
    }
}
