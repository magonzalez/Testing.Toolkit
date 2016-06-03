using System;
using System.Collections.Generic;

using Testing.Toolkit.Core.Data;

namespace Testing.Toolkit.Core
{
    public abstract class TestFixtureBase
    {
        public static readonly DateTime Today = DateTime.UtcNow;
        public static readonly DateTime NextMonth = Today.AddDays(30);
        public static readonly DateTime LastMonth = Today.AddDays(-30);
        public static readonly DateTime NextWeek = Today.AddDays(7);
        public static readonly DateTime LastWeek = Today.AddDays(-7);
        public static readonly DateTime Yesterday = Today.AddDays(-1);
        public static readonly DateTime Tomorrow = Today.AddDays(1);
        public static readonly DateTime StartOfCurrentYear = new DateTime(Today.Year, 1, 1);
        public static readonly DateTime EndOfCurrentYear = new DateTime(Today.Year, 12, 31);

        public T GetRandomElement<T>(IEnumerable<T> items)
        {
            return items.GetRandomElement();
        }

        public IEnumerable<T> GetRandomElements<T>(IEnumerable<T> items, int? count = null)
        {
            return items.GetRandomElements(count);
        }

        public bool GetRandomBool()
        {
            return RandomData.GetRandomBoolean();
        }

        public bool? GetRandomNullableBool()
        {
            return RandomData.GetRandomNullableBoolean();
        }

        public int GetRandomNumber(int minNumber = 0, int maxNumber = int.MaxValue)
        {
            return RandomData.GetRandomNumber(minNumber, maxNumber);
        }

        public int? GetRandomNullableNumber(int minNumber = 0, int maxNumber = int.MaxValue)
        {
            return RandomData.GetRandomNullableNumber(minNumber, maxNumber);
        }

        public DateTime GetRandomDateTime(int minDateOffset = 0, int maxDateOffset = 365, bool future = false)
        {
            return RandomData.GetRandomDateTime(minDateOffset, maxDateOffset, future);
        }

        public DateTime? GetRandomNullableDateTime(int minDateOffset = 0, int maxDateOffset = 365, bool future = false)
        {
            return RandomData.GetRandomNullableDateTime(minDateOffset, maxDateOffset, future);
        }

        public T GetRandomEnumValue<T>()
        {
            return RandomData.GetRandomEnumValue<T>();
        }

        public T GetRandomEnumValueNotDefault<T>()
        {
            return RandomData.GetRandomEnumNotDefault<T>();
        }
    }
}
