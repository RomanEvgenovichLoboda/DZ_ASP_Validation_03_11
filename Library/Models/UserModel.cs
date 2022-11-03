using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Unicode]
        [Required]
        [MinLength(3)]
        [MaxLength(24)]
        public string Name { get; set; }
        [Unicode]
        [Required]
        [MinLength(5)]
        [MaxLength(24)]
        public string Password { get; set; }
    }
}
