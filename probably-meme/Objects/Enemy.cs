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

        Enemy(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
            : base(_vector, _damage, _texture, _collisionRadius) { }

        public override void draw()
        {
            throw new NotImplementedException();
        }

        public override void move()
        {
            throw new NotImplementedException();
        }
    }
}
