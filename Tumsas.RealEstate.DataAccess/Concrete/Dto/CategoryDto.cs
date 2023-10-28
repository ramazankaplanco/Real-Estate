using System.ComponentModel.DataAnnotations;
using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;

namespace Tumsas.RealEstate.DataAccess.Concrete.Dto
{
    public class CategoryDto : DtoBase
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        public string ParentTitle { get; set; }

        public int? ParentId { get; set; }

        public string Description { get; set; }
    }
}