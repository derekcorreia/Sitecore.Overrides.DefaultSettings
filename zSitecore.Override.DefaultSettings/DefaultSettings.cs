using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Configuration;
using Sitecore.Abstractions;
using Sitecore.Diagnostics;
using System.Globalization;

namespace zSitecore.Override
{
    public class OverrideDefaultSettings : BaseSettings
    {
        private const string IIS_User = "IIS.User";
        private const string IIS_Password = "IIS.Password";

        private readonly BaseFactory _factory;
        private readonly BaseLog _log;

        private readonly Sitecore.Configuration.DefaultSettings _ds;

        public override string GetSetting(string name, string defaultValue)
        {
            if (name.ToLowerInvariant() == IIS_User.ToLowerInvariant() ||
                name.ToLowerInvariant() == IIS_Password.ToLowerInvariant())
            {
                string iisSettingValue = GetConnectionString(name);

                return string.IsNullOrEmpty(iisSettingValue) ? defaultValue : iisSettingValue;
            }

            return _ds.GetSetting(name, defaultValue);
        }

        public override string GetAppSetting(string name)
        {
            return _ds.GetAppSetting(name);
        }

        public override string GetAppSetting(string name, string defaultValue)
        {
            return _ds.GetAppSetting(name, defaultValue);
        }

        public override bool GetBoolSetting(string name, bool defaultValue)
        {
            return _ds.GetBoolSetting(name, defaultValue);
        }

        public override string GetConnectionString(string connectionStringName)
        {
            return _ds.GetConnectionString(connectionStringName);
        }

        public override double GetDoubleSetting(string name, double defaultValue)
        {
            return _ds.GetDoubleSetting(name, defaultValue);
        }

        public override TEnum GetEnumSetting<TEnum>(string name, TEnum defaultValue)
        {
            return _ds.GetEnumSetting<TEnum>(name, defaultValue);
        }

        public override string GetFileSetting(string name)
        {
            return _ds.GetFileSetting(name);
        }

        public override string GetFileSetting(string name, string defaultValue)
        {
            return _ds.GetFileSetting(name, defaultValue);
        }

        public override int GetIntSetting(string name, int defaultValue)
        {
            return _ds.GetIntSetting(name, defaultValue);
        }

        public override long GetLongSetting(string name, long defaultValue)
        {
            return _ds.GetLongSetting(name, defaultValue);
        }

        public override IReadOnlyCollection<string> GetPipedListSetting(string settingName, IReadOnlyCollection<string> defaultValue)
        {
            return _ds.GetPipedListSetting(settingName, defaultValue);
        }

        public override IReadOnlyCollection<string> GetPipedListSetting(string settingName, IReadOnlyCollection<string> defaultValue, PipedListTransformOptions options)
        {
            return _ds.GetPipedListSetting(settingName, defaultValue, options);
        }

        public override string GetSetting(string name)
        {
            return this.GetSetting(name, String.Empty);
        }

        public override T GetSystemSection<T>(string sectionName, bool assert)
        {
            return _ds.GetSystemSection<T>(sectionName, assert);
        }

        public override TimeSpan GetTimeSpanSetting(string name, TimeSpan defaultValue)
        {
            return _ds.GetTimeSpanSetting(name, defaultValue);
        }

        public override TimeSpan GetTimeSpanSetting(string name, TimeSpan defaultValue, CultureInfo cultureInfo)
        {
            return _ds.GetTimeSpanSetting(name, defaultValue, cultureInfo);
        }

        public OverrideDefaultSettings(BaseFactory factory, BaseLog log) 
        {
            Assert.ArgumentNotNull(factory, "factory");
            Assert.ArgumentNotNull(log, "log");
            _factory = factory;
            _log = log;
            _ds = new Sitecore.Configuration.DefaultSettings(factory, log);

        }

        public OverrideDefaultSettings() { }
        
        
    }
}
