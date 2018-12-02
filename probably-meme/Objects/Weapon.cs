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

        Weapon(Vector2 _vector, double _damage, Texture2D _texture, double _collisionRadius, float _bulletsSpeed)
            : base(_vector, _damage, _texture, _collisionRadius) {
            bulletsSpeed = _bulletsSpeed;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void move(Vector2 _mouse_coordinates) { }

        public void move ()
        {
            MouseState state = Mouse.GetState();
            vector = GameStaff.countUnitVector(new Vector2(state.X, state.Y), coordinates);
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
