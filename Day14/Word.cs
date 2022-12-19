using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class Word
    {
        private const int LENGTH = 36;

        public ulong Value { get; set; }

        public void ApplyMask(string mask)
        {
            if (mask.Length != LENGTH)
            {
                throw new ArgumentOutOfRangeException();
            }

            var binary = Convert.ToString((long)Value, 2);

            binary = PadToLength(binary, LENGTH);

            var binaryChars = binary.ToCharArray();

            // apply bitwise mask
            for (int n = 0; n < mask.Length; n++)
            {
                var m = mask[n];

                if (m == '0')
                {
                    // set 0
                    binaryChars[n] = '0';
                }
                else if (m == '1')
                {
                    // set 1
                    binaryChars[n] = '1';
                }
                else if (m == 'X')
                {
                    // don't care
                }
            }

            Value = FromBinary(new string(binaryChars));
        }

        public string ApplyMaskAsString(string mask)
        {
            if (mask.Length != LENGTH)
            {
                throw new ArgumentOutOfRangeException();
            }

            var binary = Convert.ToString((long)Value, 2);

            binary = PadToLength(binary, LENGTH);

            var binaryChars = binary.ToCharArray();

            // apply bitwise mask
            for (int n = 0; n < mask.Length; n++)
            {
                var m = mask[n];

                if (m == '0')
                {
                    // set 0
                    binaryChars[n] = '0';
                }
                else if (m == '1')
                {
                    // set 1
                    binaryChars[n] = '1';
                }
                else if (m == 'X')
                {
                    // don't care
                }
            }

            return new string(binaryChars);
        }

        public static ulong FromBinary(string value)
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

        private string PadToLength(string value, int length)
        {
            string text = value;

            if (value.Length < length)
            {
                var prefixLength = length - value.Length;
                text = new string('0', prefixLength) + text;
            }

            return text;
        }
    }
}
