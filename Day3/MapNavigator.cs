using System;
using System.Drawing;

namespace Day3
{
    public class MapNavigator
    {
        private Map _map;
        public MapNavigator(Map map)
        {
            _map = map;
        }

        public int Navigate(int right, int down)
        {
            int treeCount = 0;

            // assume do not run out of rows or columns

            var current = new Point(0, 0);
            bool finished = false;

            while (!finished)
            {
                if (IsValidPoint(current))
                {
                    var cell = _map[current.Y, current.X];

                    if (cell.IsTree())
                    {
                        treeCount++;

                        Console.WriteLine($"Tree {treeCount} found at row {current.Y}, column {current.X}");
                    }

                    current.X += right;
                    current.Y += down;
                }
                else
                {
                    Console.WriteLine($"Exhausted map at row {current.Y}, column {current.X}");
                    finished = true;
                }
            }

            return treeCount;
        }

        bool IsValidPoint(Point p)
        {
            return _map.IsValidX(p.X) && _map.IsValidY(p.Y);
        }
    }
}
