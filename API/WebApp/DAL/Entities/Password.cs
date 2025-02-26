namespace DAL.Entities
{
    public class Password
    {
        public int Id { get; set; }
        public required string Value { get; set; }
        public required string NomCompte {  get; set; }
        public int ApplicationId { get; set; }
        public Application? Application { get; set; }
    }
}
