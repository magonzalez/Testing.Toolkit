using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using Testing.Toolkit.Core;

namespace Testing.Toolkit.MsTest
{
    public abstract class BaseTestFixture : TestFixtureBase, IDisposable
    {
        protected BaseTestFixture()
        {
            InitiateTestFixtureSetUp();
        }

        [TestInitialize]
        public void Initialize()
        {
            SetUp();
        }

        [TestCleanup]
        public void Cleanup()
        {
            TearDown();
        }

        public virtual void TestFixtureSetUp()
        {
            // Do nothing for now...
        }
        
        public virtual void TestFixtureTearDown()
        {
            // Do nothing for now...
        }
        
        public virtual void SetUp()
        {
            // Do nothing for now...
        }
        
        public virtual void TearDown()
        {
            // Do nothing for now...
        }

        public static void ThrowsAsync(Func<Task> task)
        {
            AggregateException exception = null;

            try
            {
                task().Wait();
            }
            catch (AggregateException e)
            {
                exception = e;
            }

            exception.ShouldNotBeNull();
        }

        public static void ThrowsAsync<TResult>(Func<Task<TResult>> task)
        {
            AggregateException exception = null;

            try
            {
                var result = task().Result;
            }
            catch (AggregateException e)
            {
                exception = e;
            }

            exception.ShouldNotBeNull();
        }

        public static void ThrowsAsync<TException>(Func<Task> task)
        {
            AggregateException exception = null;

            try
            {
                task().Wait();
            }
            catch (AggregateException e)
            {
                exception = e;
            }

            exception.ShouldNotBeNull();
            exception.InnerExceptions.Any(e => e.GetType() == typeof(TException)).ShouldBeTrue();
        }

        public static void ThrowsAsync<TException, TResult>(Func<Task<TResult>> task)
        {
            AggregateException exception = null;

            try
            {
                var result = task().Result;
            }
            catch (AggregateException e)
            {
                exception = e;
            }

            exception.ShouldNotBeNull();
            exception.InnerExceptions.Any(e => e.GetType() == typeof(TException)).ShouldBeTrue();
        }

        private void InitiateTestFixtureSetUp()
        {
            TestFixtureSetUp();
        }

        public void Dispose()
        {
            TestFixtureTearDown();
        }
    }
}
