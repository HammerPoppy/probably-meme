using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace probably_meme.Objects
{
    class Bullet : AObject
    {
        public bool visibility;
        public Bullet(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius, float _speed)
            : base(_vector, _damage, _texture, _collisionRadius)
        {
            visibility = true;
            Random random = new Random();
            MouseState state = Mouse.GetState();
            Vector2 recoilVector = new Vector2((float)random.Next(10) / 100, (float)random.Next(10) / 100);
            vector = GameStaff.countUnitVector(new Vector2(state.X, state.Y), coordinates);
            vector += recoilVector;
            vector.X *= _speed;
            vector.Y *= _speed;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void move(Vector2 _mouse_coordinates) { }
        
        public void move()
        {
            coordinates.X += vector.X;
            coordinates.Y += vector.Y;
        }

        public Vector2 getPosition()
        {
            return coordinates;
        }

        public double getDamage()
        {
            return damage;
        }
    }
}
