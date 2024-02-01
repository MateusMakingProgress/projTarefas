using System.Text.Json.Serialization;
using System.Text.Json;

namespace tarefasAPI.Models
{
    public class Entity
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
