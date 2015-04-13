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

        /// <summary>
        /// Generates a random patron name.
        /// </summary>
        /// <param name="rng">The random number generator to use.</param>
        /// <returns>A randomly generated patron name.</returns>
        public static string RandomName()
        {
            Random rng = new Random();
            string first = FirstNames[rng.Next(FirstNames.Length)];
            string last = LastNames[rng.Next(LastNames.Length)];

            return first + " " + last;
        }

        /// <summary>
        /// Returns a random title.
        /// </summary>
        /// <param name="rng">The random number generator to use.</param>
        /// <returns>A randomly generated title.</returns>
        public static string RandomTitle(Random rng)
        {
            string adjective = Adjectives[rng.Next(Adjectives.Length)];
            string noun = Nouns[rng.Next(Nouns.Length)];

            return string.Format("The {0} {1}", adjective, noun);
        }

        /// <summary>
        /// Returns a random birthday.
        /// </summary>
        /// <param name="rng">The random number generator to use.</param>
        /// <returns>A randomly generated birthday.</returns>
        public static DateTime RandomBirthday(Random rng)
        {
            const int MAX_OFFSET = 100 * 365; // 100 years
            DateTime birthday = DateTime.Now;
            int offset = rng.Next(MAX_OFFSET);

            birthday.AddDays(-offset);

            return birthday;
        }

        /// <summary>
        /// Selects a random media type.
        /// </summary>
        /// <param name="rng">The random number generator to use.</param>
        /// <returns>A randomly chosen media type.</returns>
        public static MediaType RandomMediaType(Random rng)
        {
            const int MAX = 3;
            const int BOOK = 0;
            const int DVD = 1;
            const int VIDEO = 2;

            int choice = rng.Next(MAX);

            switch (choice)
            {
                case BOOK:
                    return MediaType.Book;
                case DVD:
                    return MediaType.DVD;
                case VIDEO:
                    return MediaType.Video;
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Selects a random media rating.
        /// </summary>
        /// <param name="rng">The random numger generator to use.</param>
        /// <returns>A randomly chosen media rating.</returns>
        public static MediaRating RandomMediaRating(Random rng)
        {
            const int MAX = 2;
            const int EVERYONE = 0;
            const int ADULT = 1;

            int choice = rng.Next(MAX);

            switch (choice)
            {
                case EVERYONE:
                    return MediaRating.Everyone;
                case ADULT:
                    return MediaRating.Adult;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}