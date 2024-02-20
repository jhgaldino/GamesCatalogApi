using ErrorOr;
using FluentValidation.Results;

namespace GamesCatalogApi.Extensions
{
    public static class FluentValidationExtensions
    {
        public static List<Error> ToValidation(this List<ValidationFailure> validations)
        {
            List<Error> errors = new();

            validations?.ForEach(error =>
            {
                errors.Add(Error.Validation(code: error.ErrorCode, description: error.ErrorMessage));
            });

            return errors;
        }
    }
}
