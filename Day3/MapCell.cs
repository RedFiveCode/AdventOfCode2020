namespace Day3
{
    public class MapCell
    {
        private char _cell;

        public MapCell(char ch)
        {
            _cell = ch;
        }

        public bool IsEmpty()
        {
            return _cell == '.';
        }

        public bool IsTree()
        {
            return _cell == '#';
        }

        public override string ToString()
        {
            return _cell.ToString();
        }
    }
}
