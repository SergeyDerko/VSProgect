using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Участники команды 
    /// </summary>
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        public string Photo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Fb { get; set; }
        public string Google { get; set; }
        public string Tw { get; set; }
        public string Inst { get; set; }
        public string City { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

    }
}
