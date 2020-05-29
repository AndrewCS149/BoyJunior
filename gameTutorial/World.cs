using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace gameTutorial
{

    // A class to initialize and draw the world to the screen
    public class World : Game
    {

        // method to draw the world to the screen
        public void drawWorld(SpriteBatch spriteBatch, TiledMapRenderer mapRenderer)
        {
            spriteBatch.Begin();
            mapRenderer.Draw();
            spriteBatch.End();
        }
    }
}
