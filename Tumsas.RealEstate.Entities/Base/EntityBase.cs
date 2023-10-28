using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tumsas.RealEstate.Core.DataAccess.Base;

namespace Tumsas.RealEstate.Entities.Base
{
    public class EntityBase : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
