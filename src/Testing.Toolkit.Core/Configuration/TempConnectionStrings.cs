using System;
using System.Collections.Generic;
using System.Configuration;

using Testing.Toolkit.Core.Extensions;

namespace Testing.Toolkit.Core.Configuration
{
    public class TempConnectionStrings : IDisposable
    {
        private readonly List<ConnectionStringSettings> _originalSettings = new List<ConnectionStringSettings>();

        public TempConnectionStrings(params ConnectionStringSettings[] settings)
        {
            var connectionString = ConfigurationManager.ConnectionStrings;

            foreach (ConnectionStringSettings cs in connectionString)
            {
                _originalSettings.Add(new ConnectionStringSettings(cs.Name, cs.ConnectionString, cs.ProviderName));
            }

            ConfigurationManager.ConnectionStrings.SetConnectionStrings(settings);
        }

        public void Dispose()
        {
            ConfigurationManager.ConnectionStrings.SetConnectionStrings(_originalSettings.ToArray());
        }
    }
}
