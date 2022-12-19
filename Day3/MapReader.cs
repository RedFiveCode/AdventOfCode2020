using System.Collections.Generic;
using System.IO;

namespace Day3
{
    public class MapReader
    {
        public Map ReadMap(string file)
        {
            var lines  = File.ReadAllLines(file);

            var rows = new List<List<MapCell>>();
            foreach (var line in lines)
            {
                var row = ParseLine(line);
                rows.Add(row);
            }

            int rowCount = rows.Count;
            int columnCount = rows[0].Count; // all rows are the same width

            var map = new Map(rowCount, columnCount);

            for (int r = 0; r < rows.Count; r++)
            {
                map.AddRow(r, rows[r]);
            }

            return map;
        }

        private List<MapCell> ParseLine(string line)
        {
            var row = new List<MapCell>();

            foreach (char ch in line)
            {
                var cell = new MapCell(ch);
                row.Add(cell);
            }
            return row;
        }
    }
}
