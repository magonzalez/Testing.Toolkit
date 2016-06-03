using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;
using Should;

using Testing.Toolkit.Core;
using Testing.Toolkit.Core.Data;

namespace Testing.Toolkit.NUnit
{
    public abstract class BaseTestFixture : TestFixtureBase
    {
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
