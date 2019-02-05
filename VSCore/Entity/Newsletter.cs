using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    public class Newsletter
    {
        [Key]
        public int NewsletterId { get; set; }
        public string Email { get; set; }

    }
}
