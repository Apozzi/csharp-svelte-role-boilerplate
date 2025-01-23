namespace Domain.Entities
{
    public class UserWithoutPassword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        
        public static UserWithoutPassword FromUser(User user)
        {
            return new UserWithoutPassword
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Roles = user.Roles
            };
        }
    }
}
