using System;
using System.Collections.Generic;

namespace Day24
{
    // See https://www.redblobgames.com/grids/hexagons/

    public class AxialCoordinate
    {
        public AxialCoordinate(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public AxialCoordinate(AxialCoordinate rhs)
        {
            X = rhs.X;
            Y = rhs.Y;
            Z = rhs.Z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public bool IsValid()
        {
            return X + Y + Z == 0;
        }

        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}}}", X, Y, Z);
        }

        public AxialCoordinate Move(Direction direction)
        {
            var newPosition = new AxialCoordinate(this);

            switch (direction)
            {
                case Direction.NE: { return Transform(1, 0, -1); };
                case Direction.E: { return Transform(1, -1, 0); };
                case Direction.SE: { return Transform(0, -1, 1); };
                case Direction.SW: { return Transform(-1, 0, 1); };
                case Direction.W: { return Transform(-1, 1, 0); };
                case Direction.NW: { return Transform(0, 1, -1); };
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public override int GetHashCode()
        {
            return (X.GetHashCode() * 17) + (Y.GetHashCode() * 37) + Z.GetHashCode();
        }

        public override bool Equals(object o)
        {
            var rhs = o as AxialCoordinate;
            return rhs != null && X == rhs.X && Y == rhs.Y && Z == rhs.Z;
        }

        public bool Equals(AxialCoordinate rhs)
        {
            return rhs != null && X == rhs.X && Y == rhs.Y && Z == rhs.Z;
        }

        private AxialCoordinate Transform(int dx, int dy, int dz)
        {
            var newPosition = new AxialCoordinate(this);

            newPosition.X += dx;
            newPosition.Y += dy;
            newPosition.Z += dz;

            return newPosition;
        }

        public IEnumerable<AxialCoordinate> GetNeighbours()
        {
            return new List<AxialCoordinate>()
            {
                Move(Direction.NE),
                Move(Direction.E),
                Move(Direction.SE),
                Move(Direction.SW),
                Move(Direction.W),
                Move(Direction.NW),
            };
        }
    }
}
