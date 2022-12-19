using System.Collections.Generic;
using System.Diagnostics;

namespace Day24
{
    [DebuggerDisplay("{Position} {Colour}")]
    public class Tile
    {
        public Tile(AxialCoordinate position)
        {
            Position = position;
            FlipCount = 0;
            Colour = "white";
        }

        public AxialCoordinate Position { get; private set; }
        public int FlipCount { get; private set; }
        public string Colour { get; private set; }

        public bool EqualsPosition(int x, int y, int z)
        {
            return Position.X == x && Position.Y == y && Position.Z == z;
        }

        public bool EqualsPosition(AxialCoordinate pos)
        {
            return Position.X == pos.X && Position.Y == pos.Y && Position.Z == pos.Z;
        }

        public void FlipTile()
        {
            FlipCount++;

            if (Colour == "white")
            {
                Colour = "black";
            }
            else
            {
                Colour = "white";
            }
        }

        // Part two
        public IEnumerable<AxialCoordinate> GetNeighbours()
        {
            return new List<AxialCoordinate>()
            {
                Position.Move(Direction.NE),
                Position.Move(Direction.E),
                Position.Move(Direction.SE),
                Position.Move(Direction.SW),
                Position.Move(Direction.W),
                Position.Move(Direction.NW),
            };
        }
    }
}
