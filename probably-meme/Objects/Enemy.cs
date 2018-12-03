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
        float speed;

        public Enemy(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius, double _HitPoints)
            : base(_vector, _damage, _texture, _collisionRadius) {
            collisionRadius = _collisionRadius;
            speed = 1;
            HitPoints = _HitPoints;
        }

        public void setSpeed(double _speed)
        {
            speed = (float)_speed;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width, texture.Height), Color.White);
            spriteBatch.End();
        }

        public override void move(Vector2 _point)
        {
            vector = GameStaff.countUnitVector(_point, coordinates);
            vector.X *= speed;
            vector.Y *= speed;

            coordinates.X += vector.X;
            coordinates.Y += vector.Y;
        }

        public void setHitPoints(double _hp)
        {
            HitPoints = _hp;
        }

        public double attack()
        {
            return (damage);
        }

        public void take_damage(double _dmg)
        {
            HitPoints -= _dmg;
        }

        public double getHp()
        {
            return HitPoints;
        }

        public bool isLive()
        {
            return (HitPoints > 0);
        }

        public Vector2 getPosition()
        {
            return coordinates;
        }
        
        public double getCollisionRadius()
        {
            return collisionRadius;
        }
    }
}
