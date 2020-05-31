using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Content;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using SharpDX.MediaFoundation;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;

namespace gameTutorial
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        private TiledMapLayer bottomLayer;
        private TiledMapLayer middleLayer;
        private TiledMapLayer topLayer;
        public static TiledMapObject collisionObject;
        public static TiledMapObject collisionObject2;
        public TiledMapObjectLayer objectLayer;

        Texture2D playerSprite;
        Player player;

        public static TiledMap map;
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

            //player.initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            //Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load player
            playerSprite = Content.Load<Texture2D>("Imgs/blue-shirt-guy");
            player = new Player(200f, playerSprite.Width, playerSprite.Height, playerSprite);

            // import tmx map
            map = Content.Load<TiledMap>("maps/terrain");

            // grab bottom layer and top layer
            bottomLayer = map.GetLayer<TiledMapLayer>("bottomLayer");
            middleLayer = map.GetLayer<TiledMapLayer>("middleLayer");
            topLayer = map.GetLayer<TiledMapLayer>("topLayer");
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            mapRenderer.LoadMap(map);

            // collision variables
            collisionObject = map.GetLayer<TiledMapObjectLayer>("collision").Objects.ElementAt<TiledMapObject>(0);
            collisionObject2 = map.GetLayer<TiledMapObjectLayer>("collision").Objects.ElementAt<TiledMapObject>(1);
            objectLayer = map.GetLayer<TiledMapObjectLayer>("collision");
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

            // update player position
            player.updatePosition(gameTime);

            // collision detection
            for (int i = 0; i < objectLayer.Objects.Length; i++)
            {
                collisionObject = map.GetLayer<TiledMapObjectLayer>("collision").Objects.ElementAt<TiledMapObject>(i);
                player.collision(collisionObject);

            }
            player.setBoundaries(mapWidth, mapHeight);

            // update tmx map
            mapRenderer.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mapRenderer.Draw(bottomLayer);
            mapRenderer.Draw(middleLayer);
            player.drawPlayer(spriteBatch);
            mapRenderer.Draw(topLayer);

            base.Draw(gameTime);
        }
    }
}
