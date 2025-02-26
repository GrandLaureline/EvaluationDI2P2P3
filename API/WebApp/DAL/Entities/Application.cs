namespace DAL.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<Password> Passwords { get; set; } = new();
    }
}
