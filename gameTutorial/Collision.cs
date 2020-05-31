using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gameTutorial
{
    static class Collision
    { 

        private static TiledMapObject obstruction;
        private static Vector2 position;
        private static Texture2D sprite;

        public static void colDetection(Texture2D sprite)
        {
            obstruction = Game1.map.GetLayer<TiledMapObjectLayer>("collision").Objects.ElementAt<TiledMapObject>(0);

            float objX = obstruction.Position.X;
            float objY = obstruction.Position.Y;
            float objHeight = obstruction.Size.Height;
            float objWidth = obstruction.Size.Width;

            float buff1 = sprite.Width / 2; // compensate for player width
            float buff2 = sprite.Width / 2 + 4;

            // Collision properties

            // left
            if (position.X > objX - buff1 &&
                position.X < objX + objWidth + buff1 &&
                position.Y > objY - buff1 &&
                position.Y < objY + objHeight + buff1)
            {
                position.X = objX - buff1;
            }

            // top
            if (position.Y > objY - buff2 &&
                position.Y < objY + objHeight &&
                position.X > objX - buff1 &&
                position.X < objX + objWidth + buff1)
            {
                position.Y = objY - buff2;
            }

            // right
            if (position.X < objX + objWidth + buff2 &&
                position.X > objX - buff1 &&
                position.Y > objY - buff1 &&
                position.Y < objY + objHeight + buff1)
            {
                position.X = objX + objWidth + buff2;
            }

            // bottom 
            if (position.Y < objY + objHeight + buff2 &&
                position.Y > objY &&
                position.X > objX - buff1 &&
                position.X < objX + objWidth + buff1)
            {
                position.Y = objY + objHeight + buff2;
            }
        }
    }
}
