using Newtonsoft.Json;

namespace BookStore.Requests
{
    public class SignInRequest
    {
        [JsonProperty(Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }
    }
}