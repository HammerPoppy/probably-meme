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
        private float speed;
        private double hitPoints { get; set; }

        public Player(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
             : base(_vector, _damage, _texture, _collisionRadius) {
            speed = 1;
        }

        public override void move(Vector2 _vector)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) && state.IsKeyDown(Keys.W))
            {
                coordinates.X -= (float)(speed / Math.Sqrt(2));
                coordinates.Y -= (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.W) && state.IsKeyDown(Keys.D))
            {
                coordinates.X += (float)(speed / Math.Sqrt(2));
                coordinates.Y -= (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.D) && state.IsKeyDown(Keys.S))
            {
                coordinates.X += (float)(speed / Math.Sqrt(2));
                coordinates.Y += (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.S) && state.IsKeyDown(Keys.A))
            {
                coordinates.X -= (float)(speed / Math.Sqrt(2));
                coordinates.Y += (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.A))
                coordinates.X -= speed;
            else if (state.IsKeyDown(Keys.D))
                coordinates.X -= speed;
            else if (state.IsKeyDown(Keys.W))
                coordinates.Y -= speed;
            else if (state.IsKeyDown(Keys.S))
                coordinates.Y -= speed;
            //weapon.move(_vector);
        }

        public void setSpeed(double _speed)
        {
            speed = (float)_speed;
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
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
                weapon.attack();
        }

        public double collision(Enemy enemy)
        {
            return weapon.collision(enemy);
        }

        public Vector2 getPosition()
        {
            return coordinates;
        }
    }
}
