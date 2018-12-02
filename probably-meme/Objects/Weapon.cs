using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probably_meme.Objects
{
    class Weapon : AObject
    {
        List<Bullet> bullets;
        Texture2D bulletsTexture;

        Weapon(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
            : base(_vector, _damage, _texture, _collisionRadius) { }

        public override void draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void move(Vector2 _mouse_coordinates) { }

        public void move ()
        {
            MouseState state = Mouse.GetState();

            vector.X = state.X - coordinates.X;
            vector.Y = state.Y - coordinates.Y;
            vector.X = vector.X / ((float)Math.Sqrt(vector.X * vector.X) + (float)Math.Sqrt(vector.Y * vector.Y));
            vector.Y = vector.Y / ((float)Math.Sqrt(vector.X * vector.X) + (float)Math.Sqrt(vector.Y * vector.Y));
        }

        public void changeBulletsTexture(Texture2D _texture)
        {
            bulletsTexture = _texture;
        }

        public void attack()
        {
            bullets.Add(new Bullet(coordinates, damage, bulletsTexture, 0));
        }
    }
}
