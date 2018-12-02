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
        private double hitPoints { get; set; }

        public Player(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius)
             : base(_vector, _damage, _texture, _collisionRadius) { }

        public override void move(Vector2 _vector)
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
            weapon.move(_vector);
        }


        public void changeWeapon(Weapon _weapon)
        {
            weapon = _weapon;
        }

        public override void draw()
        {
            throw new NotImplementedException();
        }

        public void attack()
        {
            weapon.attack();
        }
    }
}
