using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace probably_meme.Objects
{
    abstract class AObject
    {
        protected Vector2       coordinates;
        protected double        damage;
        protected Texture2D     texture;
        protected double        collisionRadius;



        public AObject(Vector2 _coordinates, double _damage, Texture2D _texture, double _collisionRadius)
        {
            coordinates = _coordinates;
            damage = _damage;
            texture = _texture;
            collisionRadius = _collisionRadius;
        }
        public abstract void move();
        public abstract void draw();
    }
}
