using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace BrokenFlameGames
{
    public static class BFG_BigNumbers
    {
        private static readonly string[] suffixes = { "", "K", "M", "B", "T" };

        // Main entry points (fastest overload approach)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FormatBigNumber(int value) =>
            value < 1000 ? value.ToString("0.00") : FormatBig(new BigInteger(value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FormatBigNumber(long value) =>
            value < 1000 ? value.ToString("0.00") : FormatBig(new BigInteger(value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FormatBigNumber(float value) =>
            value < 1000f ? value.ToString("0.00") : FormatBig(new BigInteger((double)value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FormatBigNumber(double value) =>
            value < 1000d ? value.ToString("0.00") : FormatBig(new BigInteger(value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FormatBigNumber(BigInteger value) =>
            value < 1000 ? ((double)value).ToString("0.00") : FormatBig(value);


        // Handles K, M, B, T formatting
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string FormatBig(BigInteger number)
        {
            int suffixIndex = 0;
            BigInteger shortened = number;

            while (shortened >= 1000 && suffixIndex < suffixes.Length - 1)
            {
                shortened /= 1000;
                suffixIndex++;
            }

            if (shortened >= 1000)
                return ToScientific(number);

            double shortValue = (double)number / Math.Pow(1000, suffixIndex);

            return shortValue < 100
                ? shortValue.ToString("0.00") + suffixes[suffixIndex]
                : shortValue.ToString("0.#") + suffixes[suffixIndex];
        }

        // Scientific fallback
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string ToScientific(BigInteger number)
        {
            string s = number.ToString();
            int exponent = s.Length - 1;

            if (s.Length == 1)
                return s;

            string mantissa = s[0] + "." + s.Substring(1, Math.Min(2, s.Length - 1));
            return $"{mantissa}e+{exponent}";
        }
    }
}
