using System.ComponentModel.DataAnnotations;
using Tumsas.RealEstate.Entities.Base;

namespace Tumsas.RealEstate.Entities
{
    public class RoomNumber : EntityBase
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}