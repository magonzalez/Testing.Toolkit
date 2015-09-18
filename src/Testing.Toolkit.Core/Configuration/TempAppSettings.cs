using System;
using System.Collections.Generic;
using System.Configuration;

using Testing.Toolkit.Core.Extensions;

namespace Testing.Toolkit.Core.Configuration
{
    public class TempAppSettings : IDisposable
    {
        private readonly Dictionary<string, string> _originalSettings = new Dictionary<string, string>();

        public TempAppSettings(Dictionary<string, string> tempSettings)
        {
            var appSettings = ConfigurationManager.AppSettings;

            foreach (var setting in appSettings.AllKeys)
            {
                _originalSettings.Add(setting, appSettings[setting]);
            }

            ConfigurationManager.AppSettings.SetAppSettings(tempSettings);
        }

        public void Dispose()
        {
            ConfigurationManager.AppSettings.SetAppSettings(_originalSettings);
        }
    }
}
