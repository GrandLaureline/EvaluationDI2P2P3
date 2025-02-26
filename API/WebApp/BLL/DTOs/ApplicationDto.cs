using DAL.Entities;

namespace BLL.DTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<Password> Passwords { get; set; } = new();
    }
}
