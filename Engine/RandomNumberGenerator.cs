﻿using System;
using System.Security.Cryptography;

namespace Engine
{
    // This is the more complex version
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            var randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            var asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and subtracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            var multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            var range = maximumValue - minimumValue + 1;

            var randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }

        // Simple version, with less randomness.
        //
        // If you want to use this version, 
        // you can delete (or comment out) the NumberBetween function above,
        // and rename this from SimpleNumberBetween to NumberBetween
        private static readonly Random _simpleGenerator = new Random();

        public static int SimpleNumberBetween(int minimumValue, int maximumValue)
            => _simpleGenerator.Next(minimumValue, maximumValue + 1);
    }
}
