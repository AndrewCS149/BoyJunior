using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;

namespace gameTutorial
{
    class Player : Game
    {
        Vector2 position;
        float speed;
        GraphicsDeviceManager graphics;
        private int width;
        private int height;
        Texture2D sprite;

        public Player(float speed, int width, int height, Texture2D sprite)
        {
            this.sprite = sprite;
            this.width = width;
            this.height = height;
            this.speed = speed;
            graphics = new GraphicsDeviceManager(this);
        }

        // a method to initialize the player's starting position and to set the 
        // initial speed
        public void initialize()
        {
            position = new Vector2(graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);
        }

        // a method to update the position of the player based on the key press
        public void updatePosition(GameTime gameTime)
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
                
            Game1.collisionObject = Game1.map.GetLayer<TiledMapObjectLayer>("collision").Objects.ElementAt<TiledMapObject>(0);
            //Console.WriteLine(Game1.collisionObject.Objects.ElementAt<TiledMapObject>(0).Position.X);

            float objectX = Game1.collisionObject.Position.X;
            float objectY = Game1.collisionObject.Position.Y;

            if (position.X > objectX - sprite.Width / 2)
            {
                //position.Y = position.Y;
                position.X = objectX - sprite.Width / 2;
            }
        }

        // a method to set the window boundaries of the player
        public void setBoundaries(int width, int height)
        {
            if (position.X > width - sprite.Width / 2)
                position.X = width - sprite.Width / 2;
            else if (position.X < sprite.Width / 2)
                position.X = sprite.Width / 2;

            if (position.Y > height - sprite.Height / 2)
                position.Y = height - sprite.Height / 2;
            else if (position.Y < sprite.Height / 2)
                position.Y = sprite.Height / 2;
        }

        // a method to draw the player to the screen
        public void drawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
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
