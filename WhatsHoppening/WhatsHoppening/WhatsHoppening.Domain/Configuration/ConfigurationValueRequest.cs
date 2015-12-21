namespace WhatsHoppening.Domain.Configuration
{
    public class ConfigurationValueRequest
    {
        public static implicit operator ConfigurationValueRequest(string sectionName)
        {
            return new ConfigurationValueRequest() { SectionName = sectionName };
        }

        public string SectionName { get; set; }
    }
}
