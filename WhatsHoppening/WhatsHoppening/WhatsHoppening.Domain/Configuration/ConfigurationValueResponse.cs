namespace WhatsHoppening.Domain.Configuration
{
    public class ConfigurationValueResponse
    {
        public static implicit operator ConfigurationValueResponse(string value)
        {
            return new ConfigurationValueResponse() { Value = value };
        }

        public string Value { get; set; }
    }
}
