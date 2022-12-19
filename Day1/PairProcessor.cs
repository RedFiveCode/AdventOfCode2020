namespace Day1
{
    class PairProcessor
    {
        public bool IsTwentyTwenty(Pair p)
        {
            return IsMatchingSum(p, 2020);
        }

        private bool IsMatchingSum(Pair p, int target)
        {
            return p.Sum() == target;
        }
    }
}
