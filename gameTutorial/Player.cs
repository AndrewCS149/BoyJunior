using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gameTutorial
{

    class Player : Game
    {
        Vector2 position;
        Vector2 mapPosition;
        float speed;
        GraphicsDeviceManager graphics;

        public Player()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        // a method to initialize the player's starting position and to set the 
        // initial speed
        public void initialize()
        {
            position = new Vector2(graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);

            mapPosition = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

            // set player speed
            speed = 500f;
        }

        // a method to update the position of the player based on the key press
        public void updatePosition(GameTime gameTime, Texture2D sprite)
        {
            var keyState = Keyboard.GetState();

            // enable movement with keypresses
            if (keyState.IsKeyDown(Keys.W))
                position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.S))
                position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.A))
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.D))
                position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        // a method to set the window boundaries of the player
        public void setBoundaries(Texture2D sprite)
        {
            if (position.X > graphics.PreferredBackBufferWidth - sprite.Width / 2)
                position.X = graphics.PreferredBackBufferWidth - sprite.Width / 2;
            else if (position.X < sprite.Width / 2)
                position.X = sprite.Width / 2;

            if (position.Y > graphics.PreferredBackBufferHeight - sprite.Height / 2)
                position.Y = graphics.PreferredBackBufferHeight - sprite.Height / 2;
            else if (position.Y < sprite.Height / 2)
                position.Y = sprite.Height / 2;
        }

        // a method to return the position of the player
        public Vector2 getPosition()
        {
            return position;
        }

        // a method to draw the player to the screen
        public void drawPlayer(SpriteBatch spriteBatch, Texture2D sprite, Texture2D map)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(
                map,
                mapPosition,
                null,
                Color.White,
                0f,
                new Vector2(map.Width, map.Height),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            spriteBatch.Draw(
                sprite,
                position,
                null,
                Color.White,
                0f,
                new Vector2(sprite.Width / 2, sprite.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            spriteBatch.End();
        }
    }
}
