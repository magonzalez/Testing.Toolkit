using FizzWare.NBuilder;
using NUnit.Framework;

using Testing.Toolkit.Core.Data;

namespace Testing.Toolkit.Core
{
    [SetUpFixture]
    public class ToolkitSetUpFixture
    {
        [SetUp]
        public void SetUp()
        {
            var namer = new SqlValuePropertyNamer(new RandomGenerator());

            BuilderSetup.SetDefaultPropertyNamer(namer);
        }
    }
}
