using Microsoft.Xna.Framework;
using System;

namespace probably_meme.Objects
{
    static class GameStaff
    {
        public static Vector2 countUnitVector(Vector2 point, Vector2 coordinates)
        {
            Vector2 vector;
            Vector2 result;
            vector.X = point.X - coordinates.X;
            vector.Y = point.Y - coordinates.Y;
            result.X = vector.X / (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            result.Y = vector.Y / (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            return result;
        }

        public static Vector2 randomEnemyPosition()
        {
            Vector2 position;
            Random random = new Random();
            int randomNumber = random.Next(0, 2);

            if (randomNumber == 1)
                position.X = 1920;
            else
                position.X = 0;
            position.Y = random.Next(0, 1080);
            return position;
        }
    }
}
