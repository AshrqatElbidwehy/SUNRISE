using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUNRISE.Models
{
    [Table("Chef")]
    public class Chef
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 11, MinimumLength = 11)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Chef()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
        }
    }
}
