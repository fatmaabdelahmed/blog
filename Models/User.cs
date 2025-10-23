using System.ComponentModel.DataAnnotations;

namespace blog.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
