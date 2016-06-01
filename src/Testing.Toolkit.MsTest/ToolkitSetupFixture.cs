using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.Toolkit.Core.Data;

namespace Testing.Toolkit.MsTest
{
    public class ToolkitSetUpFixture
    {
        [AssemblyInitialize]
        public void SetUp()
        {
            var namer = new SqlValuePropertyNamer(new RandomGenerator());

            BuilderSetup.SetDefaultPropertyNamer(namer);
        }
    }
}
