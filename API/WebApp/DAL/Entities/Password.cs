namespace DAL.Entities
{
    public class Password
    {
        public int Id { get; set; }
        /// <summary>
        /// Contient le mot de passe chiffré.
        /// </summary>
        public string Value { get; set; } = string.Empty;
        public int ApplicationId { get; set; }
        public Application? Application { get; set; }
    }
}
