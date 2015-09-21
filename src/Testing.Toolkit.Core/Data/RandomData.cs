using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Testing.Toolkit.Core.Data
{
    public static class RandomData
    {
        public static Random RandomNumber = new Random();

        public static T GetRandomElement<T>(this IEnumerable<T> items)
        {
            var itemList = items.ToList();
            var idx = RandomNumber.Next(0, itemList.Count());

            return itemList.ElementAt(idx);
        }

        public static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> items, int? count = null)
        {
            var elements = new Collection<T>();

            var itemList = items.ToList();
            count = count.HasValue ? count : RandomNumber.Next(0, itemList.Count());
            while (elements.Count != count.Value)
            {
                var assessment = itemList.GetRandomElement();
                if (!elements.Contains(assessment))
                    elements.Add(assessment);
            }

            return elements;
        }

        public static bool GetRandomBoolean()
        {
            return (RandomNumber.Next(0, 1000) % 2) == 0;
        }

        public static int GetRandomNumber(int minNumber = 0, int maxNumber = int.MaxValue)
        {
            return RandomNumber.Next(minNumber, maxNumber);
        }

        public static DateTime GetRandomDateTime(int minDateOffset = 0, int maxDateOffset = 365, bool future = false)
        {
            if (future && minDateOffset <= 0)
            {
                minDateOffset = 1;
            }

            var dateOffset = RandomNumber.Next(minDateOffset, maxDateOffset);

            return future ? DateTime.UtcNow.AddDays(dateOffset)
                : DateTime.UtcNow.AddDays(0 - dateOffset);
        }

        public static T GetRandomEnumValue<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new InvalidEnumArgumentException(string.Format("Type [{0}] is not an enum", type.Name));

            var values = Enum.GetValues(type);

            return (T)values.GetValue(RandomNumber.Next(0, values.Length));
        }
    }
}
