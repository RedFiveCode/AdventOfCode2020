using System;
using System.Linq;
using System.Collections.Generic;

namespace Day14
{
    public class MemoryAddressDecoder
    {
        private const int LENGTH = 36;

        public List<string> GetExpandedFloatingAddresses(string mask)
        {
            var results = new List<string>();

            int xCount = mask.Count(ch => ch == 'X');
            ulong permutationCount = (ulong)Math.Pow(2, xCount);

            for (ulong i = 0; i < permutationCount; i++)
            {
                var expandedMask = ApplyFloatingAddressMask(mask, i);
                results.Add(expandedMask);
            }

            return results;
        }

        public List<ulong> GetExpandedFloatingAddressesAsNumber(string mask)
        {
            var results = new List<ulong>();

            int xCount = mask.Count(ch => ch == 'X');
            ulong permutationCount = (ulong)Math.Pow(2, xCount);

            for (ulong i = 0; i < permutationCount; i++)
            {
                var expandedMask = ApplyFloatingAddressMask(mask, i);
                var result = FromBinary(expandedMask);
                results.Add(result);
            }

            return results;
        }

        public string ApplyFloatingAddressMask(string mask, ulong value)
        {
            var valueText = PadToLength(ConvertToString(value), LENGTH);

            var result = mask.ToCharArray();

            int maskIndex = valueText.Length - 1;
            for (int i = mask.Length -1 ; i >= 0; i--)
            {
                if (mask[i] == 'X')
                {
                    result[i] = valueText[maskIndex];
                    maskIndex--;
                }
            }

            return new string(result);
        }

        public string ApplyAddressMask(string mask, ulong value)
        {
            var valueText = PadToLength(ConvertToString(value), LENGTH);

            var result = new char[LENGTH];

            int maskIndex = valueText.Length - 1;
            for (int i = mask.Length - 1; i >= 0; i--)
            {
                if (mask[i] == '0')
                {
                    result[i] = valueText[i]; // unchanged
                }
                else if (mask[i] == '1')
                {
                    result[i] = '1';  // set to one
                }
                else if (mask[i] == 'X')
                {
                    result[i] = 'X';
                }
            }

            return new string(result);
        }

        public string ConvertToString(ulong value)
        {
            return Convert.ToString((long)value, 2);
        }

        public string PadToLength(string value, int length)
        {
            string text = value;

            if (value.Length < length)
            {
                var prefixLength = length - value.Length;
                text = new string('0', prefixLength) + text;
            }

            return text;
        }

        public ulong FromBinary(string value)
        {
            return FromBinary(value.ToCharArray());
        }

        public ulong FromBinary(char[] value)
        {
            ulong multiplier = 1;
            ulong sum = 0;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (value[i] == '1')
                {
                    sum += multiplier;
                }

                multiplier *= 2;
            }

            return sum;
        }
    }
}
