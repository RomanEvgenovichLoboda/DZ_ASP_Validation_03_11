using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class ChengeDataModel:DataModel
    {
        [Unicode]
        [Required]
        [MinLength(5)]
        [MaxLength(24)]
        public string NewPassword { get; set; }
    }
}
