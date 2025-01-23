using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore] 
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
