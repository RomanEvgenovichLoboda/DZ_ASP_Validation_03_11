using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
