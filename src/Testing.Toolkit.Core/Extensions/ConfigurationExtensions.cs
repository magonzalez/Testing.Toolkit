using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

namespace Testing.Toolkit.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void SetConnectionStrings(this ConnectionStringSettingsCollection connectionStrings, params ConnectionStringSettings[] settings)
        {
            var readonlyField = typeof(ConfigurationElementCollection).GetField("bReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            // ReSharper disable once PossibleNullReferenceException
            readonlyField.SetValue(connectionStrings, false);

            var baseClearMethod = typeof(ConfigurationElementCollection).GetMethod("BaseClear", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { }, null);
            baseClearMethod.Invoke(connectionStrings, new object[] { });

            var baseAddMethod = typeof(ConfigurationElementCollection).GetMethod("BaseAdd", BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(ConfigurationElement) }, null);

            if (settings != null && settings.Length > 0)
            {
                foreach (var setting in settings)
                {
                    baseAddMethod.Invoke(connectionStrings, new object[] { setting });
                }
            }

            readonlyField.SetValue(connectionStrings, true);
        }

        public static void SetAppSettings(this NameValueCollection appSettings, Dictionary<string, string> settings)
        {
            var readonlyProperty = typeof(NameObjectCollectionBase).GetField("_readOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            if (readonlyProperty != null)
            {
                readonlyProperty.SetValue(appSettings, false);

                var baseClearMethod = typeof(NameObjectCollectionBase).GetMethod("BaseClear", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { }, null);
                baseClearMethod.Invoke(appSettings, new object[] { });

                if ((settings != null) && (settings.Count > 0))
                {
                    var baseAddMethod = typeof(NameValueCollection).GetMethod("BaseAdd", BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(string), typeof(object) }, null);

                    foreach (var setting in settings.Keys)
                    {
                        baseAddMethod.Invoke(appSettings, new object[] { setting, new ArrayList(1) { settings[setting] } });
                    }
                }

                readonlyProperty.SetValue(appSettings, true);
            }
        }
    }
}
