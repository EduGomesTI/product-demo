using FluentValidation.Results;
using System.Runtime.Serialization;

namespace Product.Domain.Bases.Error
{
    [Serializable]
    public class InvalidValidationResultException : Exception
    {
        public ValidationResult? ValidationResult { get; }

        public InvalidValidationResultException()
        {
        }

        public InvalidValidationResultException(string? message) : base(message)
        {
        }

        public InvalidValidationResultException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidValidationResultException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidValidationResultException(string message, ValidationResult validationResult) : this(message)
        {
            ValidationResult = validationResult;
        }
    }
}
