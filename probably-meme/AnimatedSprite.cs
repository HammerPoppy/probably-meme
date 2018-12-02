using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace probably_meme
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int framesFromChange;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            framesFromChange = 0;
        }

        public void Update()
        {
            framesFromChange++;
            if (framesFromChange >= 5)
            {
                currentFrame++;
                framesFromChange = 0;
            }
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void StartAnimation()
        {

        }

        public void StopAnimation()
        {
            currentFrame = 0;
            framesFromChange = 0;
        }

        /*spriteBatch.Draw(texture, new Rectangle((int) coordinates.X,
            (int) coordinates.Y, texture.Width, texture.Height), Color.White);*/
        public void Draw(SpriteBatch spriteBatch, Rectangle location, Color color, bool flip)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            spriteBatch.Begin();
            if (flip)
            {
                spriteBatch.Draw(Texture, location, sourceRectangle, color,
                    0, new Vector2(width / 2, height / 2), SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(Texture, location, sourceRectangle, color,
                                    0, new Vector2(width / 2, height / 2), SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }

    }
}
