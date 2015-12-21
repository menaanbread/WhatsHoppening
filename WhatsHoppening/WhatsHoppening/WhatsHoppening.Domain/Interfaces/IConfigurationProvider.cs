using WhatsHoppening.Domain.Configuration;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface IConfigurationProvider
    {
        ConfigurationValueResponse Read(ConfigurationValueRequest configurationValueRequest);
    }
}
