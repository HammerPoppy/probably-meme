using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace probably_meme.Objects
{
    class Weapon : AObject
    {
        private List<Bullet> bullets;
        private Texture2D bulletsTexture;
        private float bulletsSpeed;
        private SoundEffect[] shoot;
        private int framesFromLastAttack = 0;
        private int attackCooldown = 7;
        private Vector2 origin;
        double rotationAngle;

        public Weapon(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius, float _bulletsSpeed, SoundEffect[] shootSounds)
            : base(_vector, _damage, _texture, _collisionRadius) {
            bulletsSpeed = _bulletsSpeed;
            coordinates = _vector;
            origin.X = 0;
            origin.Y = 0;
            bullets = new List<Bullet>();
            shoot = shootSounds;
        }

        public void changeCoordinates(Vector2 point)
        {
            coordinates.X += point.X;
            coordinates.Y += point.Y;
        }

        public void changeOrigin(Vector2 point)
        {
            origin.X = point.X;
            origin.Y = point.Y;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            spriteBatch.Draw(texture, new Rectangle((int)(coordinates.X - 5 + origin.X), (int)(coordinates.Y - 35 + origin.Y), texture.Width, texture.Height),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)(rotationAngle /*+ (Math.PI * 0.5f)*/), origin, SpriteEffects.None, (float)0);
            bullets.ForEach(delegate (Bullet bullet)
            {
                if (bullet.visibility)
                    spriteBatch.Draw(bulletsTexture, bullet.getPosition(), Color.White);
            });
            spriteBatch.End();
        }

        public override void move(Vector2 _mouse_coordinates) { }

        public void move()
        {
            MouseState state = Mouse.GetState();
            Vector2 mousePosition = new Vector2(state.X, state.Y);
            vector = GameStaff.countUnitVector(new Vector2(state.X, state.Y), 
                new Vector2(coordinates.X, coordinates.Y));

            Vector2 direction = mousePosition - coordinates;
            rotationAngle = (float)Math.Atan2(direction.Y, direction.X);

            bullets.ForEach(delegate (Bullet bullet)
            {
                bullet.move();
            });
        }

        public void changeBulletsTexture(Texture2D _texture)
        {
            bulletsTexture = _texture;
        }

        public void attack()
        {
            Random random = new Random();
            framesFromLastAttack++;
            if (framesFromLastAttack >= attackCooldown)
            {
                switch (random.Next() % 3)
                {
                    case 0:
                        shoot[0].Play();
                        break;
                    case 1:
                        shoot[1].Play();
                        break;
                    case 2:
                        shoot[2].Play();
                        break;
                }
                bullets.Add(new Bullet(coordinates, damage, bulletsTexture, 0, bulletsSpeed));
                framesFromLastAttack = 0;
            }
        }

        public double collision(Enemy enemy)
        {
            Vector2 bulletPosition;
            Vector2 enemyPosition = enemy.getPosition();
            double _damage = 0;
            bullets.ForEach(delegate (Bullet bullet)
            {
                bulletPosition = bullet.getPosition();
                
                if ((enemyPosition.X + enemy.getCollisionRadius() >= bulletPosition.X) &&
                    (enemyPosition.X  <= bulletPosition.X) &&
                    (enemyPosition.Y + enemy.getCollisionRadius()  >= bulletPosition.Y) &&
                    (enemyPosition.Y <= bulletPosition.Y))
                {
                    
                   if (bullet.visibility)
                        _damage += damage;
                    bullet.visibility = false;
                }
            });
            return _damage;
        }
    }
}
