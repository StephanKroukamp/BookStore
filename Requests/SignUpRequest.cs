using Newtonsoft.Json;

namespace BookStore.Requests
{
    public class SignUpRequest
    {
        [JsonProperty(Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }
    }
}