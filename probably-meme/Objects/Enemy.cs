using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace probably_meme.Objects
{
    class Enemy : AObject
    {
        double HitPoints;

        public Enemy(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
            : base(_vector, _damage, _texture, _collisionRadius) { }

        public override void draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void move(Vector2 _point)
        {
            vector.X = _point.X - coordinates.X;
            vector.Y = _point.Y - coordinates.Y;
            vector.X = vector.X / ((float)Math.Sqrt(vector.X * vector.X) + (float)Math.Sqrt(vector.Y * vector.Y));
            vector.Y = vector.Y / ((float)Math.Sqrt(vector.X * vector.X) + (float)Math.Sqrt(vector.Y * vector.Y));

            coordinates.X += vector.X;
            coordinates.Y += vector.Y;
        }

        void setHitPoints(double _hp)
        {
            HitPoints = _hp;
        }

        double attack()
        {
            return (damage);
        }
    }
}
