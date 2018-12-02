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

        Player(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
             : base(_vector, _damage, _texture, _collisionRadius) { }
        public override void move()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                coordinates.X--;
            else if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
                coordinates.X++;
            else if (state.IsKeyUp(Keys.W) || state.IsKeyDown(Keys.Up))
                coordinates.Y++;
            else if (state.IsKeyUp(Keys.S) || state.IsKeyUp(Keys.Down))
                coordinates.Y--;
            weapon.move();
        }

        public override void draw()
        {
            
        }

        public void changeWeapon(Weapon _weapon)
        {
            weapon = _weapon;
        }
    }
}
