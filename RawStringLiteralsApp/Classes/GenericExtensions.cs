﻿using System.Numerics;

namespace RawStringLiteralsApp.Classes
{
    public static class GenericExtensions
    {
        /// <summary>Determines if a value represents an even integral value.</summary>
        public static bool IsEven<T>(this T sender) where T : INumber<T>
            => T.IsEvenInteger(sender);
        /// <summary>Determines if a value represents an odd integral value.</summary>
        public static bool IsOdd<T>(this T sender) where T : INumber<T>
            => T.IsOddInteger(sender);
    }
}
