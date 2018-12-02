using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


namespace probably_meme.Objects
{
    class Player : AObject
    {
        public override void move()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left)
                coordinates.X++;
        }

        public override void draw()
        {
            
        }
    }
}
