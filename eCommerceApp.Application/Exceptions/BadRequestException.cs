using FluentValidation.Results;

namespace eCommerceApp.Application.Exceptions
{
#pragma warning disable RCS1194 // Implement exception constructors.

    public class BadRequestException : Exception
#pragma warning restore RCS1194 // Implement exception constructors.
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception? innerException) : base(message, innerException)
        {
        }

        public BadRequestException(string? message, List<ValidationResult> validationResults) : base(message)
        {
            foreach (ValidationResult result in validationResults)
            {
                result.ToDictionary().ToList().ForEach(x => ValidationErrors.Add(x.Key, x.Value));
            }
        }

        public IDictionary<string, string[]> ValidationErrors { get; set; } = new Dictionary<string, string[]>();
    }
}