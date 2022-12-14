using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class DataModel
    {
        [Unicode]
        [Required]
        [MinLength(5)]
        [MaxLength(24)]
        public string Login { get; set; }
        [Unicode]
        [Required]
        [MinLength(5)]
        [MaxLength(24)]
        public string Password { get; set; }
    }
}
