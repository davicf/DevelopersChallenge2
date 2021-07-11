using FluentValidation.Results;
using System.Linq;

namespace Xayah.Finances.Domain.Common.Extension
{
    public static class ValidationResultExtension
    {
        public static ValidationResultRules Verify(this ValidationResult validation)
        {
            var errors = validation.Errors.Select(x => x.ErrorMessage);

            return new ValidationResultRules { IsValid = validation.IsValid, Errors = errors };
        }
    }
}