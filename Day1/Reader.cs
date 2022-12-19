using System.Collections.Generic;

namespace Day1
{
    class Reader
    {
        public List<Pair> ReadPairData()
        {
            var processor = new PairProcessor();

            var results = new List<Pair>();

            for (int i = 0; i < RawData.Data.Count; i++)
            {
                for (int j = 0; j < RawData.Data.Count; j++)
                {
                    if (i != j) // new two different items to form a pair
                    {
                        var p = new Pair(RawData.Data[i], RawData.Data[j]);

                        if (processor.IsTwentyTwenty(p))
                        {
                            results.Add(p);
                        }
                    }
                }
            }

            return results;
        }

        public List<Triple> ReadTripleData()
        {
            var processor = new TripleProcessor();

            var results = new List<Triple>();

            for (int i = 0; i < RawData.Data.Count; i++)
            {
                for (int j = 0; j < RawData.Data.Count; j++)
                {
                    for(int k = 0; k < RawData.Data.Count; k++)
                    { 
                        var t = new Triple(RawData.Data[i], RawData.Data[j], RawData.Data[k]);

                        if (processor.IsTwentyTwenty(t))
                        {
                            results.Add(t);
                        }
                    }
                }
            }

            return results;
        }
    }
}
