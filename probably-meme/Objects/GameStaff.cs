using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probably_meme.Objects
{
    static class GameStaff
    {
        public static Vector2 countUnitVector(Vector2 point, Vector2 coordinates)
        {
            Vector2 vector;
            vector.X = point.X - coordinates.X;
            vector.Y = point.Y - coordinates.Y;
            vector.X = vector.X / (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector.Y = vector.Y / (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            return vector;
        }

        public static Vector2 randomEnemyPosition()
        {
            Vector2 position;
            int[] randomX = { 0, 1920 };
            int[] randomY = { 0, 1080 }; 

            position.X = 0;
            position.Y = 0;

            return position;
        }
    }
}
