using System.Text.Json.Serialization;

namespace TCP.Model
{
    public class DeviceBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string type { get; set; }
        [JsonPropertyName("deviceName")]
        public string deviceName { get; set; }
        [JsonPropertyName("location")]
        public string location { get; set; }
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("LastStateChange")]
        public int LastStateChange { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }


        public DeviceBase()
        {

        }
    }
}
