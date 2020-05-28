using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameTutorial
{

    // A class to initialize and draw the world to the screen
    class World : Game
    {
        Vector2 position;

        GraphicsDeviceManager graphics;

        public World()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        // set the map position and size
        public void initialize()
        {
            position = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
            //position = new Vector2(width, height);
        }

        // draw the map
        public void drawWorld(SpriteBatch spriteBatch, Texture2D map) 
        {
            spriteBatch.Begin();
            spriteBatch.Draw(
                map,
                position,
                null,
                Color.White,
                0f,
                new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            spriteBatch.End();
        }
    }
}
