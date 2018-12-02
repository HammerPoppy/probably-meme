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
            vector = GameStaff.countUnitVector(_point, coordinates);
            
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

        bool live()
        {
            return (HitPoints <= 0);
        }
    }
}
