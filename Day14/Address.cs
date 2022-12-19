using System;
using System.Linq;

namespace Day14
{
    public class Address
    {
        private const int LENGTH = 36;

        private string _address;

        public Address(string value)
        {
            Update(value);
        }

        public Address(ulong value)
        {
            _address = PadToLength(ConvertToString(value), LENGTH);
        }

        public void Update(string value)
        {
            if (value.Length != LENGTH)
            {
                throw new ArgumentOutOfRangeException();
            }

            _address = value;
        }

        public string ConvertFloatingAddressMask(ulong value)
        {
            var valueText = PadToLength(ConvertToString(value), LENGTH);

            var result = _address.ToCharArray();

            int maskIndex = valueText.Length - 1;
            for (int i = _address.Length - 1; i >= 0; i--)
            {
                if (_address[i] == 'X')
                {
                    result[i] = valueText[maskIndex];
                    maskIndex--;
                }
            }

            return new string(result);
        }

        public bool ContainsFloatingValues()
        {
            return _address.Any(c => c == 'X');
        }

        public int FloatingValueCount()
        {
            return _address.Count(c => c == 'X');
        }

        public override string ToString()
        {
            return _address;
        }

        public ulong ToNumber()
        {
            return FromBinary(_address);
        }

        private static string ConvertToString(ulong value)
        {
            return Convert.ToString((long)value, 2);
        }

        private static string PadToLength(string value, int length)
        {
            string text = value;

            if (value.Length < length)
            {
                var prefixLength = length - value.Length;
                text = new string('0', prefixLength) + text;
            }

            return text;
        }

        private static ulong FromBinary(string value)
        {
            return FromBinary(value.ToCharArray());
        }

        private static ulong FromBinary(char[] value)
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
