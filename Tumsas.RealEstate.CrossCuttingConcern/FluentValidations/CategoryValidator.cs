using FluentValidation;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;

namespace Tumsas.RealEstate.CrossCuttingConcern.FluentValidations
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            // add rules
        }
    }
}