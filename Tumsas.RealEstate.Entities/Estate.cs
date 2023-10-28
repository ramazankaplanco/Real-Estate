using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tumsas.RealEstate.Core.Enums;
using Tumsas.RealEstate.Entities.Base;

namespace Tumsas.RealEstate.Entities
{
    public class Estate : EntityBase
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


        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("RoomNumberId")]
        public virtual RoomNumber RoomNumber { get; set; }

        [ForeignKey("BuildingAgeId")]
        public virtual BuildingAge BuildingAge { get; set; }
        
        [ForeignKey("FloorNumberId")]
        public virtual FloorNumber FloorNumber { get; set; }
    }
}