using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace probably_meme.Objects
{
    class Player : AObject
    {
        public Weapon weapon;
        private float speed;
        public double hitPoints { get; set; }
        private const int invincibleFrames = 300;
        private int invincibleFramesLeft = 0;

        

        enum AnimationStates
        {
            Going,
            Standing
        }
        AnimationStates states;

        AnimatedSprite going;

        public Player(Vector2 _vector, double _damage, Texture2D texture, double _collisionRadius, double _HitPoints)
             : base(_vector, _damage, texture, _collisionRadius)
        {
            hitPoints = _HitPoints;
            going = new AnimatedSprite(texture, 3, 2);
            states = AnimationStates.Standing;
        }

        public override void move(Vector2 mousePosition)
        {
            KeyboardState state = Keyboard.GetState();
            states = AnimationStates.Standing;
            if (state.IsKeyDown(Keys.A) && state.IsKeyDown(Keys.W))
            {
                coordinates.X -= (float)(speed / Math.Sqrt(2));
                coordinates.Y -= (float)(speed / Math.Sqrt(2));
                weapon.changeCoordinates(new Vector2((float)(-speed / Math.Sqrt(2)), (float)(-speed / Math.Sqrt(2))));
                states = AnimationStates.Going;
            }
            else if (state.IsKeyDown(Keys.W) && state.IsKeyDown(Keys.D))
            {
                coordinates.X += (float)(speed / Math.Sqrt(2));
                coordinates.Y -= (float)(speed / Math.Sqrt(2));
                weapon.changeCoordinates(new Vector2((float)(speed / Math.Sqrt(2)), (float)(-speed / Math.Sqrt(2))));
                states = AnimationStates.Going;
            }
            else if (state.IsKeyDown(Keys.D) && state.IsKeyDown(Keys.S))
            {
                coordinates.X += (float)(speed / Math.Sqrt(2));
                coordinates.Y += (float)(speed / Math.Sqrt(2));
                weapon.changeCoordinates(new Vector2((float)(speed / Math.Sqrt(2)), (float)(speed / Math.Sqrt(2))));
                states = AnimationStates.Going;
            }
            else if (state.IsKeyDown(Keys.S) && state.IsKeyDown(Keys.A))
            {
                coordinates.X -= (float)(speed / Math.Sqrt(2));
                coordinates.Y += (float)(speed / Math.Sqrt(2));
                weapon.changeCoordinates(new Vector2((float)(-speed / Math.Sqrt(2)), (float)(speed / Math.Sqrt(2))));
                states = AnimationStates.Going;
            }
            else if (state.IsKeyDown(Keys.A))
            {
                coordinates.X -= speed;
                states = AnimationStates.Going;
                weapon.changeCoordinates(new Vector2((float)-speed, 0));
            }
            else if (state.IsKeyDown(Keys.D))
            {
                coordinates.X += speed;
                weapon.changeCoordinates(new Vector2((float)speed, 0));
                states = AnimationStates.Going;
            }
            else if (state.IsKeyDown(Keys.W))
            {
                coordinates.Y -= speed;
                weapon.changeCoordinates(new Vector2(0, (float)-speed));
                states = AnimationStates.Going;
            }
            else if (state.IsKeyDown(Keys.S))
            {
                coordinates.Y += speed;
                weapon.changeCoordinates(new Vector2(0, (float)speed));
                states = AnimationStates.Going;
            }
            /*MouseState state1 = Mouse.GetState();
            if(state1.LeftButton == ButtonState.Pressed)
            {
                weapon.attack();
            }*/
            attack();
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
            case AnimationStates.Going:
                going.Draw(spriteBatch, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width / 2, texture.Height / 3),
                    Color.White, false);
                going.Update();
                break;

            case AnimationStates.Standing:
                going.StopAnimation();
                going.Update();
                going.Draw(spriteBatch, new Rectangle((int)coordinates.X, (int)coordinates.Y, texture.Width / 2, texture.Height / 3),
                        Color.White, false);
                break;
            }
            
        }

        public void attack()
        {
            MouseState state = Mouse.GetState();
                if (state.LeftButton == ButtonState.Pressed)
                    weapon.attack();
        }

        public double collision(Enemy enemy)
        {
            Vector2 enemyPosition = enemy.getPosition();

            if (invincibleFramesLeft > 0)
            {
                invincibleFramesLeft--;
                return weapon.collision(enemy);
            }
            else if ((enemyPosition.X + enemy.getCollisionRadius() >= coordinates.X) &&
                    (enemyPosition.X <= coordinates.X) &&
                    (enemyPosition.Y + enemy.getCollisionRadius() >= coordinates.Y) &&
                    (enemyPosition.Y <= coordinates.Y))
            {

                hitPoints -= enemy.attack();
                invincibleFramesLeft = invincibleFrames;
            }
            return weapon.collision(enemy);
        }

        public Vector2 getPosition()
        {
            return coordinates;
        }

        public void getDamage(double _damage)
        {
            hitPoints -= _damage;
        }

        public bool isLive()
        {
            if (hitPoints < 0)
                hitPoints = 0;
            return (hitPoints > 0);
        }
    }
}
