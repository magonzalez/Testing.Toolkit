using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Should;
using Testing.Toolkit.Core.Data;

namespace Testing.Toolkit.NUnit
{
    public abstract class BaseTestFixture
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

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            // Do nothing for now...
        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown()
        {
            // Do nothing for now...
        }

        [SetUp]
        public virtual void SetUp()
        {
            // Do nothing for now...
        }

        [TearDown]
        public virtual void TearDown()
        {
            // Do nothing for now...
        }

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

        public static void ThrowsAsync(Func<Task> task)
        {
            var exception = Assert.Catch<AggregateException>(() => task().Wait());

            exception.ShouldNotBeNull();
        }

        public static void ThrowsAsync<TResult>(Func<Task<TResult>> task)
        {
            // ReSharper disable once UnusedVariable
            var exception = Assert.Catch<AggregateException>(() => { var result = task().Result; });

            exception.ShouldNotBeNull();
        }

        public static void ThrowsAsync<TException>(Func<Task> task)
        {
            var exception = Assert.Catch<AggregateException>(() => task().Wait());

            exception.ShouldNotBeNull();
            exception.InnerExceptions.Any(e => e.GetType() == typeof(TException)).ShouldBeTrue();
        }

        public static void ThrowsAsync<TException, TResult>(Func<Task<TResult>> task)
        {
            // ReSharper disable once UnusedVariable
            var exception = Assert.Catch<AggregateException>(() => { var result = task().Result; });

            exception.ShouldNotBeNull();
            exception.InnerExceptions.Any(e => e.GetType() == typeof(TException)).ShouldBeTrue();
        }
    }
}
