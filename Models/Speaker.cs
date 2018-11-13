using Newtonsoft.Json;
using Sparrow.Json;

namespace ravendb_getting_started.Models
{
    public class Speaker
    {
        public string Id { get; set; }

        [JsonIgnore]
        public string ClientId => DocumentId.NoPrefix(Id);

        public string Name { get; set; }

        public string Bio { get; set; }
    }
}