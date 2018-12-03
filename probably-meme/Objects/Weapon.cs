using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probably_meme.Objects
{
    class Weapon : AObject
    {
        private List<Bullet> bullets;
        private Texture2D bulletsTexture;
        private float bulletsSpeed;
        private Vector2 origin;
        double rotationAngle;

        public Weapon(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius, float _bulletsSpeed)
            : base(_vector, _damage, _texture, _collisionRadius) {
            bulletsSpeed = _bulletsSpeed;
            coordinates = _vector;
            origin.X = 0;
            origin.Y = 0;
            bullets = new List<Bullet>();
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
            /*spriteBatch.Draw(texture, new Rectangle((int)(coordinates.X + origin.X), (int)(coordinates.Y + origin.Y), texture.Width, texture.Height), Color.White);*/
            //Draw(Texture, location, sourceRectangle, color,
            //      0, new Vector2(width / 2, height / 2), SpriteEffects.FlipHorizontally, 0);
            
            Rectangle sourceRectangle = new Rectangle(0, 0, (int)texture.Width, (int)texture.Height);
            spriteBatch.Draw(texture, new Rectangle((int)(coordinates.X + origin.X), (int)(coordinates.Y + origin.Y), texture.Width, texture.Height),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)(rotationAngle), origin, SpriteEffects.None, (float)0);
            bullets.ForEach(delegate (Bullet bullet)
            {
                spriteBatch.Draw(bulletsTexture, bullet.getPosition(), Color.White);
            });
            spriteBatch.End();
        }

        public override void move(Vector2 _mouse_coordinates) { }

        public void move()
        {
            MouseState state = Mouse.GetState();
            Vector2 oldVector = vector;
            vector = GameStaff.countUnitVector(new Vector2(state.X, state.Y), 
                new Vector2(coordinates.X, coordinates.Y));

            rotationAngle = oldVector.X * vector.X + oldVector.Y * vector.Y;

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
            bullets.Add(new Bullet(coordinates, damage, bulletsTexture, 0, 1));
        }

        public double collision(Enemy enemy)
        {
            Vector2 bulletPosition;
            double _damage = 0;
            bullets.ForEach(delegate (Bullet bullet)
            {
                bulletPosition = bullet.getPosition();
                if ((coordinates.X + collisionRadius >= bulletPosition.X) &&
                    (coordinates.X - collisionRadius <= bulletPosition.X) &&
                    (coordinates.Y + collisionRadius >= bulletPosition.Y) &&
                    (coordinates.Y - collisionRadius <= bulletPosition.Y))
                {
                    bullets.Remove(bullet);
                    _damage += damage;
                }
            });
            return _damage;
        }
    }
}
