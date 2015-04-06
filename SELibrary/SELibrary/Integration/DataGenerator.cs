using System.Collections.Generic;
using System;

namespace SELibrary.Integration
{
    static class DataGenerator
    {
        private static string[] FirstNames =
        {
            "John",
            "Jack",
            "Joe",
            "John",
            "Jim",
            "Jane",
            "Jill",
            "Jan",
            "Jen",
            "June"
        };

        private static string[] LastNames =
        {
            "Smith",
            "Doe",
            "Fisher",
            "Baker",
            "House",
            "Townsend",
            "Castle",
            "Cheswick",
            "Jameson",
            "Lastname"
        };

        public static string RandomName()
        {
            Random rng = new Random();
            string first = FirstNames[rng.Next(FirstNames.Length)];
            string last = LastNames[rng.Next(LastNames.Length)];

            return first + " " + last;
        }
    }
}