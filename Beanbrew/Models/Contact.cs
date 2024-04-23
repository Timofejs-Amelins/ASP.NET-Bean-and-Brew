using System.ComponentModel.DataAnnotations;

namespace Beanbrew.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
