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

        private static string[] Adjectives =
        {
            "Big",
            "Little",
            "Orange",
            "Forgotten",
            "Missing",
            "Fuzzy",
            "Bald",
            "Suspicious",
            "Friendly",
            "Invisible"
        };

        private static string[] Nouns =
        {
            "Dog",
            "Cat",
            "Fish",
            "Book",
            "Car",
            "Train",
            "Soup",
            "Shoes",
            "Door",
            "Sock"
        };

        public static string RandomName()
        {
            Random rng = new Random();
            string first = FirstNames[rng.Next(FirstNames.Length)];
            string last = LastNames[rng.Next(LastNames.Length)];

            return first + " " + last;
        }

        public static string RandomTitle(Random rng)
        {
            string adjective = Adjectives[rng.Next(Adjectives.Length)];
            string noun = Nouns[rng.Next(Nouns.Length)];

            return string.Format("The {0} {1}", adjective, noun);
        }
    }
}