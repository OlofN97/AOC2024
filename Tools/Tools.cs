using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Tools
{
    public static class Tools
    {
        public static Point[] LinearDirections = new Point[]
            {
                new Point(0, 1),
                new Point( 1,0 ),
                new Point(0, -1),
                new Point( -1,0 )
            };

        public static bool CheckOoB(Point position, Point direction, int height, int width)
        {
            Point move = position + direction;
            if (move.x < 0 || move.y < 0) return false;
            if (move.x >= width || move.y >= height) return false;
            return true;
        }
    }



    public struct Point
    {
        public int x;
        public int y;

        public Point(int y, int x)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point A, Point B)
        {
            Point point = new Point();
            point.x = A.x + B.x;
            point.y = A.y + B.y;
            return point;
        }

        public static Point operator -(Point A, Point B)
        {
            Point point = new Point();
            point.x = A.x - B.x;
            point.y = A.y - B.y;
            return point;
        }

        public static bool operator ==(Point A, Point B)
        {
            if (A.x == B.x && A.y == B.y) return true;

            return false;
        }
        public static bool operator !=(Point A, Point B)
        {
            if (A.x != B.x || A.y != B.y) return true;

            return false;
        
        
        }
        public static Point operator *(Point A, int b)
        {
            return new Point(A.y * b, A.x * b);
        }
    }


}
