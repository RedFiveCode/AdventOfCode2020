namespace Day1
{
    class TripleProcessor
    {
        public bool IsTwentyTwenty(Triple t)
        {
            return IsMatchingSum(t, 2020);
        }

        private bool IsMatchingSum(Triple t, int target)
        {
            return t.Sum() == target;
        }
    }
}
