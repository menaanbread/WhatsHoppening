using System;
using System.Configuration;
using WhatsHoppening.Domain.Configuration;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.ConfigurationProvider
{
    public class ConfigFileConfigurationProvider : IConfigurationProvider
    {
        ConfigurationValueResponse IConfigurationProvider.Read(ConfigurationValueRequest configurationValueRequest)
        {
            ConfigurationValueResponse configurationValueResponse = null;

            try
            {
                configurationValueResponse = ConfigurationManager.AppSettings[configurationValueRequest.SectionName];
            }
            catch (Exception e)
            {
                throw new ApplicationException("An exception occurred attempting to call ConfigFileConfigurationProvider.Read.", e);
            }

            return configurationValueResponse;
        }
    }
}
