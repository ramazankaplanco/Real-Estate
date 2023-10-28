﻿using FluentValidation;

namespace Tumsas.RealEstate.CrossCuttingConcern.Utilities
{
    public class ValidatorToolUtil
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);

            var result = validator.Validate(context);

            if (result.Errors.Count > 0)
                throw new ValidationException(result.Errors);
        }
    }
}