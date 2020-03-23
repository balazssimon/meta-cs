using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.GraphViz
{
    public struct Point2D
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point2D(string xy, double dpi)
        {
            X = 0;
            Y = 0;
            if (xy == null) return;
            var parts = xy.Trim().Split(',');
            if (parts.Length != 2) return;
            if (double.TryParse(parts[0], out var x) && double.TryParse(parts[1], out var y))
            {
                X = x/dpi;
                Y = y/dpi;
            }
        }

        public double X { get; }
        public double Y { get; }

        public static bool operator==(Point2D left, Point2D right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Point2D left, Point2D right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

    }
}
