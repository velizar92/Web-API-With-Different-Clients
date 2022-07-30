namespace ProgrammingConsoleWebClient.ViewModels
{
    using System.Text.Json.Serialization;
    public class Tutorial
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
