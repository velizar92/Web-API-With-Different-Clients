namespace ProgrammingConsoleWebClient.ViewModels
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    public class ProgrammingLanguage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tutorials")]
        public ICollection<Tutorial> Tutorials { get; set; }
    }
}
