using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameTutorial
{



    class boundaries
    {
        Vector2 guyPosition;
        GraphicsDeviceManager graphics;
        Texture2D guySprite;
        float guySpeed;

        public boundaries()
        {
        // set window bounds
        if (guyPosition.X > graphics.PreferredBackBufferWidth - guySprite.Width / 2)
            guyPosition.X = graphics.PreferredBackBufferWidth - guySprite.Width / 2;
        else if (guyPosition.X < guySprite.Width / 2)
            guyPosition.X = guySprite.Width / 2;

        if (guyPosition.Y > graphics.PreferredBackBufferHeight - guySprite.Height / 2)
            guyPosition.Y = graphics.PreferredBackBufferHeight - guySprite.Height / 2;
        else if (guyPosition.Y<guySprite.Height / 2)
            guyPosition.Y = guySprite.Height / 2;
        }
    }

}
