namespace Day1
{
    class Pair
    {
        public int First { get; private set; }
        public int Second { get; private set; }

        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int Sum()
        {
            return First + Second;
        }

        public int Product()
        {
            return First * Second;
        }


        public override string ToString()
        {
            return $"{First}, {Second}";
        }
    }
}
