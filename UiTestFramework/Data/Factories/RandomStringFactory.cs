using System;
using Bogus;

namespace UiTestFramework.Data.Factories
{
    public static class RandomStringFactory
    {
        public static string GetRandomString(int length)
        {
            return new Faker().Random.String(length, 'a', 'z');
        }

        public static char GetRandomCharFromString(string value)
        {
            return value[new Random().Next(value.Length)];
        }
    }
}