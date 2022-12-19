using System;
using System.Linq;
using System.Collections.Generic;

namespace Day14
{

    public class MemoryPartTwo
    {
        private const int LENGTH = 36;

        private Dictionary<ulong, ulong> _map = new Dictionary<ulong, ulong>();
        private string _mask;
        private MemoryAddressDecoder decoder = new MemoryAddressDecoder();

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

        public ulong this[ulong address]
        {
            set
            {
                var addressesWithPartiallyAppliedMask = decoder.ApplyAddressMask(_mask, address);

                var addressList = decoder.GetExpandedFloatingAddressesAsNumber(addressesWithPartiallyAppliedMask);

                if (addressList.Count == 0)
                {
                    // no addresses
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    foreach (var modifiedAddress in addressList)
                    {
                        Console.WriteLine($"{address} -> {modifiedAddress} : {value}");
                        _map[modifiedAddress] = value;
                    }
                }

            }
        }

        public double Sum()
        {
            return _map.Sum(v => (long)v.Value);
        }

        private static ulong ApplyMask(ulong address, string mask)
        {
            return ApplyMask(address, mask.ToCharArray());
        }

        private static ulong ApplyMask(ulong address, char[] mask)
        {
            var addressText = Convert.ToString((long)address, 2);
            addressText = PadToLength(addressText, LENGTH);

            var result = new char[LENGTH];
            for (int n = 0; n < mask.Length; n++)
            {
                if (mask[n] == '0')
                {
                    result[n] = addressText[n];
                }
                else if (mask[n] == '1')
                {
                    result[n] = '1';
                }
            }

            return FromBinary(result);
        }

        public static List<string> ExpandAddressMask(string mask)
        {
            return ExpandAddressMask(mask.ToCharArray());
        }

        public static List<string> ExpandAddressMask(char[] mask)
        {
            // expands any X floatng bits in the mask, does not apply the mask to the address

            var results = new List<string>();

            if (mask.Any(c => c == 'X'))
            {
                var currentMask = new string(mask).ToCharArray();

                for (int n = 0; n < mask.Length; n++)
                {
                    if (currentMask[n] == 'X')
                    {
                        currentMask[n] = '0';
                        results.AddRange(ExpandAddressMask(currentMask));

                        currentMask[n] = '1';
                        results.AddRange(ExpandAddressMask(currentMask));
                    }
                }
            }
            else
            {
                results.Add(new string(mask));
            }

            return results.Distinct().ToList();
        }

        public static List<ulong> GetExpandedAddresses(ulong address, string mask)
        {
            var addressMasks = ExpandAddressMask(mask);

            return addressMasks.Select(m => ApplyMask(address, m)).ToList();
        }

        public static List<ulong> ApplyAddressMask(ulong address, string mask)
        {
            return ApplyAddressMask(address, mask.ToCharArray());
        }

        public static List<ulong> ApplyAddressMask(ulong address, char[] mask)
        {
            var addresses = new List<ulong>();

            var currentMask = new string(mask).ToCharArray();

            for (int n = 0; n < currentMask.Length; n++)
            {
                var m = currentMask[n];

                if (m == '0')
                {
                    // no change
                }
                else if (m == '1')
                {
                    // set 1
                    currentMask[n] = '1';
                }
                else if (m == 'X')
                {
                    // floating

                    // while contains X
                    //   replace X with 0 and add to results
                    //   replace X with 1 and add to results

                    currentMask[n] = '0';

                    if (currentMask.Any(c => c == 'X'))
                    {
                        addresses.AddRange(ApplyAddressMask(address, currentMask));
                    }

                    currentMask[n] = '1';

                    if (currentMask.Any(c => c == 'X'))
                    {
                        addresses.AddRange(ApplyAddressMask(address, currentMask));
                    }
                }
            }

            if (currentMask.All(c => c == '0' || c == '1'))
            {
                // apply the mask
                addresses.Add(ApplyMask(address, currentMask));
            }

            return addresses;
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
