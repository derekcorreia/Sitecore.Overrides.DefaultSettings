using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Abstractions;

namespace zSitecore.Override
{
    class DefaultSettingsServiceConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            foreach (var item in serviceCollection)
            {
                if (item.ServiceType == typeof(BaseSettings))
                {
                    serviceCollection.Remove(item);
                    break;
                }
            }
            serviceCollection.Add(ServiceDescriptor.Singleton(typeof(BaseSettings), typeof(OverrideDefaultSettings)));
        }
    }
}
