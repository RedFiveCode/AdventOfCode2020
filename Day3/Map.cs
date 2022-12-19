using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class Map
    {
        private MapCell[,] _grid;
        public Map(int rows, int columns)
        {
            _grid = new MapCell[rows, columns];
        }

        public void Add(int row, int column, MapCell cell)
        {
            _grid[row, column] = cell;
        }

        public void AddRow(int row, IEnumerable<MapCell> cells)
        {
            for (int col = 0; col < cells.Count(); col++)
            {
                Add(row, col, cells.ElementAt(col));
            }
        }

        public MapCell this[int row, int col]
        {
            get
            {
                // each row repeats itself to the right due to arboreal genetics and biome stability...
                col = GetWrappedColumIndex(col);
                return _grid[row, col];
            }
        }

        private int GetWrappedColumIndex(int col)
        {
            // each row repeats itself to the right due to arboreal genetics and biome stability...
            return col % _grid.GetLength(1);
        }


        public bool IsValidY(int y)
        {
            // rows
            return y >= 0 && y <= _grid.GetUpperBound(0);
        }

        public bool IsValidX(int x)
        {
            // columns
            // each row repeats itself to the right due to arboreal genetics and biome stability...
            x = GetWrappedColumIndex(x);

            return x >= 0 && x <= _grid.GetUpperBound(1);
        }
    }
}
