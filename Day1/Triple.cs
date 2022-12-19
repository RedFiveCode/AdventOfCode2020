namespace Day1
{
    class Triple
    {
        public int First { get; private set; }
        public int Second { get; private set; }

        public int Third { get; private set; }

        public Triple(int first, int second, int third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public int Sum()
        {
            return First + Second + Third;
        }

        public int Product()
        {
            return First * Second * Third;
        }

        public override string ToString()
        {
            return $"{First}, {Second}, {Third}";
        }
    }
}
