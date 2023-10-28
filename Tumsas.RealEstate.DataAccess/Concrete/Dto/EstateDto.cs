using System.ComponentModel.DataAnnotations;
using Tumsas.RealEstate.Core.Enums;
using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;

namespace Tumsas.RealEstate.DataAccess.Concrete.Dto
{
    public class EstateDto : DtoBase
    {
        public int CategoryId { get; set; }

        public int RoomNumberId { get; set; }

        public int BuildingAgeId { get; set; }

        public int FloorNumberId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        [MaxLength(1024)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(16)]
        public string GrossSquareMeters { get; set; }

        [Required]
        [MaxLength(16)]
        public string NetSquareMeters { get; set; }

        public DateTime AdDate { get; set; }

        public EstateStatus EstateStatus { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Location { get; set; }

        public string Description { get; set; }
    }
}