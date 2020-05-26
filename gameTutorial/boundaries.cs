//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace gameTutorial
//{
//    class boundaries
//    {
//        //Vector2 position;
//        GraphicsDeviceManager graphics; 
//        //Texture2D sprite;
//        float guySpeed;

//        public boundaries()
//        {
//        }

//        public void setBounds(Vector2 position, GraphicsDeviceManager gr, Texture2D sprite)
//        {
//            // set window bounds
//            if (this.position.X > graphics.PreferredBackBufferWidth - this.sprite.Width / 2)
//                this.position.X = graphics.PreferredBackBufferWidth - this.sprite.Width / 2;
//            else if (this.position.X < this.sprite.Width / 2)
//                this.position.X = this.sprite.Width / 2;

//            if (this.position.Y > graphics.PreferredBackBufferHeight - this.sprite.Height / 2)
//                this.position.Y = graphics.PreferredBackBufferHeight - this.sprite.Height / 2;
//            else if (this.position.Y < this.sprite.Height / 2)
//                this.position.Y = this.sprite.Height / 2;
//        }
//    }

//}
