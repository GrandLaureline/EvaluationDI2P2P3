namespace BLL.DTOs
{
    public class PasswordDto
    {
        public int Id { get; set; }
        public required string Value { get; set; }
        public required string NomCompte { get; set; }
        public int ApplicationId { get; set; }
        public ApplicationDto? Application { get; set; }
    }
}
