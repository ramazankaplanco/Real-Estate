using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tumsas.RealEstate.Entities.Base;

namespace Tumsas.RealEstate.Entities
{
    public class Category : EntityBase
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public string Description { get; set; }


        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        [NotMapped]
        public string ParentTitle => Parent?.Title;
    }
}