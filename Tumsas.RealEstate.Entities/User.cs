using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tumsas.RealEstate.Entities.Base;

namespace Tumsas.RealEstate.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }


        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}