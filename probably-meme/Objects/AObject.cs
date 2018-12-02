using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace probably_meme.Objects
{
    class AObject
    {
        protected Vector2 coordinates;
        protected double damage;
        protected Texture2D texture;

        public abstract void move();
        public abstract void draw();
    }
}