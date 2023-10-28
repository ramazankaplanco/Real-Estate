using System.ComponentModel.DataAnnotations;
using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;

namespace Tumsas.RealEstate.DataAccess.Concrete.Dto
{
    public class UserDto : DtoBase
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

        public string FullName { get; set; }
    }
}