using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace probably_meme.Objects
{
    class Player : AObject
    {
        private Weapon weapon;
        private double hitPoints { get; set; }

        public Player(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
             : base(_vector, _damage, _texture, _collisionRadius) { }

        public override void move(Vector2 _vector)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) && state.IsKeyDown(Keys.W))
            {
                coordinates.X -= (float)(1 / Math.Sqrt(2));
                coordinates.Y -= (float)(1 / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.W) && state.IsKeyDown(Keys.D))
            {
                coordinates.X += (float)(1 / Math.Sqrt(2));
                coordinates.Y -= (float)(1 / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.D) && state.IsKeyDown(Keys.S))
            {
                coordinates.X += (float)(1 / Math.Sqrt(2));
                coordinates.Y += (float)(1 / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.S) && state.IsKeyDown(Keys.A))
            {
                coordinates.X -= (float)(1 / Math.Sqrt(2));
                coordinates.Y += (float)(1 / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.A))
                coordinates.X--;
            else if (state.IsKeyDown(Keys.D))
                coordinates.X++;
            else if (state.IsKeyDown(Keys.W))
                coordinates.Y--;
            else if (state.IsKeyDown(Keys.S))
                coordinates.Y++;
            //weapon.move(_vector);
        }


        public void changeWeapon(Weapon _weapon)
        {
            weapon = _weapon;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width, texture.Height), Color.White);
        }

        public void attack()
        {
            weapon.attack();
        }
    }
}
