using System;
using System.Linq;
using System.Collections.Generic;

namespace Day14
{
    public class Memory
    {
        private const int LENGTH = 36;

        private Dictionary<ulong, ulong> _map = new Dictionary<ulong, ulong>();
        private string _mask;

        public string Mask
        {
            get { return _mask; }

            set
            {
                if (value.Length != LENGTH)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _mask = value;
            }
        }

        public ulong this [ulong address]
        {
            set
            {
                _map[address] = ApplyMask(value, _mask);
            }
        }

        public double Sum()
        {
            return _map.Sum(v => (long)v.Value);
        }

        private static ulong ApplyMask(ulong value, string mask)
        {
            var w = new Word();
            w.Value = value;
            w.ApplyMask(mask);

            return w.Value;
        }
    }
}
