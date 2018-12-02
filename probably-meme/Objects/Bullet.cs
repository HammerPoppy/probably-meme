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
    class Bullet : AObject
    {
        Bullet(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
            : base(_vector, _damage, _texture, _collisionRadius)
        {
            MouseState state = Mouse.GetState();
            vector.X = state.X - coordinates.X;
            vector.Y = state.Y - coordinates.Y;
            vector.X = vector.X / ((float)Math.Sqrt(vector.X * vector.X) + (float)Math.Sqrt(vector.Y * vector.Y));
            vector.Y = vector.Y / ((float)Math.Sqrt(vector.X * vector.X) + (float)Math.Sqrt(vector.Y * vector.Y));

        }

        public override void draw()
        {
            throw new NotImplementedException();
        }

        public override void move(Vector2 _mouse_coordinates) { }
        
        public void move()
        {
            coordinates.X += vector.X;
            coordinates.Y += vector.Y;
        }
    }
}
