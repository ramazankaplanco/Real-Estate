using System.ComponentModel.DataAnnotations;
using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;

namespace Tumsas.RealEstate.DataAccess.Concrete.Dto
{
    public class RoomNumberDto : DtoBase
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}