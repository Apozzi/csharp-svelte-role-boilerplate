using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] 
        public List<User> Users { get; set; } = new List<User>();

        public const string Admin = "Admin";
        public const string Modifier = "Modifier";
        public const string Viewer = "Viewer";
    }
}