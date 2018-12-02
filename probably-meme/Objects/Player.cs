using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace probably_meme.Objects
{
    class Player : AObject
    {
        private Weapon weapon;
        private float speed;
        private double hitPoints { get; set; }

        enum AnimationStates
        {
            Vertical,
            Left,
            Right,
            Standing
        }
        AnimationStates states;

        AnimatedSprite goingVertical, goingLeft, goingRight;

        public Player(Vector2 _vector, double _damage, Texture2D textureLeft, Texture2D textureVert, Texture2D textureStanding, double _collisionRadius)
             : base(_vector, _damage, textureStanding, _collisionRadius)
        {
            goingVertical = new AnimatedSprite(textureVert, 2, 2);
            goingLeft = new AnimatedSprite(textureLeft, 2, 2);
            goingRight = new AnimatedSprite(textureLeft, 2, 2);
            states = AnimationStates.Left;
        }

        public override void move(Vector2 mousePosition)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) && state.IsKeyDown(Keys.W))
            {
                coordinates.X -= (float)(speed / Math.Sqrt(2));
                coordinates.Y -= (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.W) && state.IsKeyDown(Keys.D))
            {
                coordinates.X += (float)(speed / Math.Sqrt(2));
                coordinates.Y -= (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.D) && state.IsKeyDown(Keys.S))
            {
                coordinates.X += (float)(speed / Math.Sqrt(2));
                coordinates.Y += (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.S) && state.IsKeyDown(Keys.A))
            {
                coordinates.X -= (float)(speed / Math.Sqrt(2));
                coordinates.Y += (float)(speed / Math.Sqrt(2));
            }
            else if (state.IsKeyDown(Keys.A))
                coordinates.X -= speed;
            else if (state.IsKeyDown(Keys.D))
                coordinates.X += speed;
            else if (state.IsKeyDown(Keys.W))
                coordinates.Y -= speed;
            else if (state.IsKeyDown(Keys.S))
                coordinates.Y += speed;
            //weapon.move(_vector);
        }

        public void setSpeed(double _speed)
        {
            speed = (float)_speed;
        }

        public void changeWeapon(Weapon _weapon)
        {
            weapon = _weapon;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width, texture.Height), Color.White);
            switch (states)
            {
            case AnimationStates.Left:
                goingLeft.Draw(spriteBatch, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width, texture.Height),
                    Color.White, false);
                goingLeft.Update();
                break;
                    
            case AnimationStates.Right:
                goingRight.Draw(spriteBatch, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width, texture.Height),
                    Color.White, true);
                goingRight.Update();
                break;

            case AnimationStates.Vertical:
                goingVertical.Draw(spriteBatch, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width, texture.Height),
                    Color.White, false);
                goingVertical.Update();
                break;

            case AnimationStates.Standing:
                goingLeft.StopAnimation();
                goingRight.StopAnimation();
                goingVertical.StopAnimation();
                break;
            }
            
        }

        public void attack()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
                weapon.attack();
        }

        public double collision(Enemy enemy)
        {
            return weapon.collision(enemy);
        }

        public Vector2 getPosition()
        {
            return coordinates;
        }
    }
}
